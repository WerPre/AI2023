using GAF.Operators;
using GAF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAF.Extensions;

namespace GenericSchedulingProblem_SA
{
    public class Genetic
    {
        private const int PopulationSize = 100;
        private List<Job>[] units;
        private int num_units;

        public Genetic(Job[] jobs, int num_units)
        {
            this.num_units = num_units;
            units = scheduling.GenerateNewSchedule(num_units, jobs);
        }

        public List<Job>[] FindBestSchedule()
        {
            Population population = new Population();

            List<Job> populationJobs = new List<Job>();

            int i = 0;

            //create the chromosomes
            for (; i < PopulationSize; i++)
            {
                var chromosome = new Chromosome();
                foreach (var unit in units)
                {
                    chromosome.Genes.Add(new Gene(unit));
                }

                chromosome.Genes.ShuffleFast();
                population.Solutions.Add(chromosome);
            }

            //create the elite operator
            var elite = new Elite(5);

            //create the crossover operator
            var crossover = new Crossover(0.8)
            {
                CrossoverType = CrossoverType.DoublePointOrdered
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

            List<Job>[] temp_schedule = new List<Job>[num_units];

            i = 0;
            foreach (var gene in best.Genes)
            {
                temp_schedule[i] = (List<Job>)gene.ObjectValue;
                i++;
            }

            return temp_schedule;
        }

        public double CalculateFitness(Chromosome chromosome)
        {
            if (CheckGeneratedSchedule(chromosome)) return 0.0; //jesli nie został poprawnie wygenerowany, to fitness = 0;

            var timeCost = CostFunction_genetic(chromosome);

            var fitness = 10 / timeCost;
            return fitness;

        }

        // składanie genow/unitów w hormonogram i liczymy koszt
        private double CostFunction_genetic(Chromosome chromosome)
        {
            List<Job>[] temp_schedule = new List<Job>[num_units];

            int i = 0;
            foreach (var gene in chromosome.Genes)
            {
                temp_schedule[i] = (List<Job>)gene.ObjectValue;
                i++;
            }

            return scheduling.CostFunction(temp_schedule, num_units);
        }

        bool CheckGeneratedSchedule(Chromosome chromosome) //upewniamy się czy wygenerowany hormonogram jest poprawny
        {
            List<Job> unit = new List<Job>();

            foreach (var gene in chromosome.Genes)
            {
                unit = (List<Job>)gene.ObjectValue;
                foreach(Job job in unit)
                {
                    if(job.PrevJob != null)
                    {
                        Job prevJob = unit.FirstOrDefault(j => j.Id == job.PrevJob);
                        if(prevJob == null) return false;
                    }                 
                }
            }

            return true;
        }

        public static bool Terminate(Population population, int currentGeneration, long currentEvaluation)
        {
            return currentGeneration > 100;
        }
    }
}
