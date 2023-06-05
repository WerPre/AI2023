using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSchedulingProblem_SA
{
    public class scheduling
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
 

        public static int CostFunction(List<Job>[] schedule, int num_units)
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
    }
}
