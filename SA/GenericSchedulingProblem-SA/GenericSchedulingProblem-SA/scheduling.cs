using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSchedulingProblem_SA
{
    public static class scheduling
    {
        public static List<Job>[] GenerateNewSchedule(int num_units, Job[] jobs)
        {
            List<Job>[] schedule = new List<Job>[num_units];
            List<Job> tempJobs = new List<Job>(jobs);
            int current_unit;
            Random rand = new Random();

            for (int i = 0; i < num_units; i++)
            {
                schedule[i] = new List<Job>();
            }

            while (tempJobs.Count() > 0)
            {
                current_unit = rand.Next(0, num_units); //tak, może sie zdarzyć, że nie wszystkie unit będą miały jakiekolwiek zadania, ale tym tu sie nie przejmujemy
                Add_Job_to_Unit(tempJobs[0], current_unit, schedule, tempJobs);
            }

            return schedule;
        }

        private static void Add_Job_to_Unit(Job job, int unit, List<Job>[] schedule, List<Job> tempJobs)
        {
            if (job.PrevJob != null)
            {
                Job prevJob = tempJobs.FirstOrDefault(j => j.Id == job.PrevJob);

                if(prevJob != null)//sprawdzamy, czy juz poprzedniego zadania nie przydzieliliśmy
                    Add_Job_to_Unit(prevJob, unit, schedule, tempJobs); //poczeka aż jego poprzednicy zostaną przydzieleni do tego unit
                
                else //musimy znaleźć unit w juz przydzielonych
                {
                    foreach(var un in schedule)
                    {
                        prevJob = un.FirstOrDefault(j => j.Id == job.PrevJob);
                        if (prevJob != null) break;
                    }
                    unit = prevJob.Unit;
                }
            }
            job.Unit = unit;
            schedule[unit].Add(job);
            tempJobs.Remove(job); //dzieki temu nie wywowały ponownie tej funkcji, tempJobs w foreach powinno dynamicznie sie skracać aż nie będzie miał kolejnych elementów 
        }

        public static double CostFunction(List<Job>[] schedule, int num_units)
        {
            int total_Time;
            int[] unit_time_sum = new int[num_units];

            for (int i = 0; i < num_units; i++)
            {
                unit_time_sum[i] = 0; //tak w razie czego gdyby miał problem z fatem, że ktoryś procesor nie miałby rzadnych zadań

                //tu zakładamy że czas dla każdego procesora zaczynamy odliczac dla pierwszych zadan od czasu rownego 0, każdy z nich rozpoczyna swoje przydzielone zadania w tym samym czasie
                //początek wykoania kolejnego zadania na każdym poszczególnym procesorze to czas zakończenia obecnego
                //dlatego dla każdego procesora czas wykonania wszystkich zadań to suma czasu potrzebnego na wykonaie każdego przydzielonego mu zadania
                foreach (Job j in schedule[i])
                {
                    unit_time_sum[i] += j.Time;
                }
            }

            total_Time = unit_time_sum.Max();
            return total_Time;
        }

        public static List<Job>[] NeighbourSchedule(List<Job>[] schedule, Random rand, int num_units)
        {
            // kopia starego harmonogramu
            List<Job>[] newSchedule = (List<Job>[])schedule.Clone();

            Job job1;
            Job job2;
            List<Job> unit1 = null;
            List<Job> unit2 = null;
            int job1Index = -1;
            int job2Index = -1;
            int unit1_num = -1;
            int unit2_num = -1;

            // wybór dwóch losowych zadań poptrz wybór dwóch dowolnych unit i 2 losowych indeksów zadań
            do
            {
                job1 = null;
                job2 = null;

                unit1_num = rand.Next(0, num_units);
                unit2_num = rand.Next(0, num_units);

                unit1 = newSchedule[unit1_num];
                unit2 = newSchedule[unit2_num];

                job1Index = rand.Next(0, unit1.Count + 1); // + 1 ponieważ ostatni index oznacza dopisanie zadania na koniec listy, a nie podmianę
                job2Index = rand.Next(0, unit2.Count + 1);

                if (unit1.Count != 0 && job1Index < unit1.Count) //sprawdzamy czy mamy tu obcje z podmiana, jesli tak, to trzeba go podpiąć pod job
                    job1 = unit1[job1Index];

                if (unit2.Count != 0 && job2Index < unit2.Count)
                    job2 = unit2[job2Index];
            } while (job1 == job2 || unit1 == unit2);// wiedząc ze zależne zadania są tylko na jednym unit, twn warunek zabezpiecza przed zamiana dwóch zadań zależnych od siebie


            // robocze listy, zawierające ciąg zadań połączonych relacjami, służą do zamiany zadań lub przeniesienia zadania na inny procesor
            List<Job> jobs1 = new List<Job>();
            List<Job> jobs2 = new List<Job>();

            if (job1 != null)
            {
                job1 = TheFirst(job1, unit1);
                job1Index = unit1.IndexOf(job1);

                // dopisywanie kolejnych zadań połączonych relacjami do roboczej listy i usuwanie ich z listy zadań procesora, bo przenosimy cały ciąg zależnych zadań
                do
                {
                    jobs1.Add(job1);
                    unit1.Remove(job1);
                    job1 = unit1.FirstOrDefault(j => j.PrevJob == job1.Id);
                } while (job1 != null);

            }

            if (job2 != null)
            {
                job2 = TheFirst(job2, unit2);
                job2Index = unit2.IndexOf(job2);

                do
                {
                    jobs2.Add(job2);
                    unit2.Remove(job2);
                    job2 = unit2.FirstOrDefault(j => j.PrevJob == job2.Id);
                } while (job2 != null);
            }


            // zamiana zadań lub przeniesienie zadania
            if (jobs2.Count != 0) //nie chemy dodawać zerowych elementów
            {
                foreach (Job job in jobs2)
                {
                    job.Unit = unit1_num;
                    //Console.WriteLine("unit: " + job.Unit.ToString() + " Id: " + job.Id.ToString());
                }
                //Console.WriteLine();

                if (job1Index <= unit1.Count)
                    unit1.InsertRange(job1Index, jobs2);
                else unit1.AddRange(jobs2);
            }
            if (jobs1.Count != 0)
            {
                foreach (Job job in jobs1)
                {
                    job.Unit = unit2_num;
                    //Console.WriteLine("unit: " + job.Unit.ToString() + " Id: " + job.Id.ToString());
                    
                }
                //Console.WriteLine();

                if (job2Index <= unit2.Count)
                    unit2.InsertRange(job2Index, jobs1);
                else unit2.AddRange(jobs1);
            }

            return newSchedule;
        }

        private static Job TheFirst(Job job, List<Job> unit) //zakładamy, ze bedziemy stosowac tej funkcji tylko do odnajdowania poprzednika na już uożonym unit
        {
            if (job.PrevJob != null)
                return TheFirst(unit.FirstOrDefault(j => j.Id == job.PrevJob), unit);
            return job;
        }
    }
}
