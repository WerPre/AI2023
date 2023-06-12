using GAF.Operators;
using GAF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAF.Extensions;
using System.CodeDom;

namespace GenericSchedulingProblem_SA
{
    public class ZipJob : Job
    {
        public List<Job> Jobs { get; set; }

        public ZipJob(int id, int time, int? prevJob = null, List<Job> jobs = null) : base(id, time, prevJob)
        {
            Id = (-1) * id - 1; //Id Zipa zawsze będą ujemne
            Jobs = jobs;
            Time = jobs.Sum(j => j.Time);
        }

        public List<Job> Rezip() 
        {
            return Jobs;
        }

    }
    public class Genetic
    {
        private const int PopulationSize = 100;
        private List<Job> Jobs;
        private int num_units;

        public Genetic(Job[] jobs, int num_units)
        {
            this.num_units = num_units;
            this.Jobs = new List<Job>(jobs);
        }

        public List<Job>[] FindBestSchedule()
        {
            Population population = new Population();

            List<Job> workJobs = new List<Job>();

            //będziemy pracować tylko na niezależnych zadań poprzez zamienianie zależnych na jeden zkomresowany
            while(Jobs.Count != 0)
            {
                Job job = Jobs[0];
                Job nextJob = Jobs.FirstOrDefault(j => j.PrevJob == job.Id);
                if (nextJob != null) //sprawdzamy czy jest od niego zależny inny
                {
                    List<Job> relatedJobs = new List<Job> { job };
                    do
                    {
                        //relatedJobs.Add(nextJob.Clone());
                        relatedJobs.Add(nextJob);
                        Jobs.Remove(nextJob);
                        nextJob = Jobs.FirstOrDefault(j => j.PrevJob == nextJob.Id);
                    } while (nextJob != null); //zakładamy, ze jedno zadanie moze miec tylko jedno zadanie wymagające bezpośrednio jego zakończenia

                    //tworzymy i dodajemy zkomresowany Job
                    workJobs.Add(new ZipJob(job.Id, 0, jobs: relatedJobs));//Time tak czy siak zostanie nadpisany przez kreatora na podstawie listy zadań
                }
                else
                    workJobs.Add(job);
                Jobs.Remove(job);
            }

            //create the chromosomes
            for (int i = 0; i < PopulationSize; i++)
            {
                var chromosome = new Chromosome();
                foreach (Job job in workJobs)
                {
                    chromosome.Genes.Add(new Gene(job));
                }

                chromosome.Genes.ShuffleFast();
                population.Solutions.Add(chromosome);
            }

            //create the elite operator
            var elite = new Elite(5);

            //create the crossover operator
            var crossover = new Crossover(0.8)
            {
                CrossoverType = CrossoverType.DoublePointOrdered,
                ReplacementMethod= ReplacementMethod.GenerationalReplacement
            };

            //create the mutation operator
            var mutate = new SwapMutate(0.02);

            //create the GA
            var ga = new GeneticAlgorithm(population, CalculateFitness);


            //add the operators
            ga.Operators.Add(elite);
            ga.Operators.Add(crossover);
            ga.Operators.Add(mutate);

            //run the GA
            ga.Run(Terminate);

            var best = ga.Population.GetTop(1)[0];

            List<Job>[] temp_schedule = JobsToSchedule(best);
          
            return temp_schedule;
        }

        public double CalculateFitness(Chromosome chromosome)
        {
            var timeCost = CostFunction_genetic(chromosome);

            var fitness = 10 / timeCost;
            return fitness;

        }

        // składanie genow/unitów w hormonogram i liczymy koszt
        private double CostFunction_genetic(Chromosome chromosome)
        {
            List<Job>[] temp_schedule = JobsToSchedule(chromosome);

            return scheduling.CostFunction(temp_schedule, num_units);
        }

        List<Job>[] JobsToSchedule(Chromosome chromosome) //upewniamy się czy wygenerowany hormonogram jest poprawny
        {
            List<Job>[] newSchedule = new List<Job>[num_units];
            for(int i = 0; i < num_units; i++)
            {
                newSchedule[i] = new List<Job>();
            }

            foreach (var gene in chromosome.Genes)
            {
                var minUnit = newSchedule.FirstOrDefault(unit => unit.Count == 0);
                if(minUnit == null)//jesli nie ma zadnego pustego unit
                    minUnit = newSchedule.FirstOrDefault(unit => unit.Sum(j => j.Time) == newSchedule.Min(u => u.Sum(j => j.Time)));

                Job job = (Job)gene.ObjectValue;

                if (job.Id < 0)
                {
                    ZipJob zipJob = ((ZipJob)job);
                    List<Job> relatedJobs = zipJob.Rezip();
                    minUnit.AddRange(relatedJobs);
                }
                else
                    minUnit.Add(job);
            }
            return newSchedule;
        }

        public static bool Terminate(Population population, int currentGeneration, long currentEvaluation)
        {
            return currentGeneration > 100;
        }
    }
}
