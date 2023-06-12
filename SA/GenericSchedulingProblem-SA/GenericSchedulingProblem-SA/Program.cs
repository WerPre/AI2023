using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom;

namespace GenericSchedulingProblem_SA
{
    static class Extensions
    {
        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
    }
    internal class Program
    {
        static void DrawSchedule(List<Job>[] schedule, int num_unit)
        {
            Console.WriteLine("--------------------------------");
            for (int i = 0; i < num_unit; i++)
            {
                Console.Write("Unit ("+ i +" ) |");
                foreach (Job job in schedule[i])
                {
                    Console.Write(" " + job.Time + " |");
                }
                Console.WriteLine("\n--------------------------------");
            }
        }
        static void Main(string[] args)
        {
            int _units = 3;
            //zakładamy, ze jedno zadanie moze miec tylko jedno zadanie wymagające bezpośrednio jego zakończenia
            Job[] _jobs = { new Job(0, 20), new Job(1, 30, 0), new Job(2, 12), new Job(3, 11) };
                        
            //Console.WriteLine(scheduling.CostFunction(_schedule, _units));

            Stopwatch SA_time = new Stopwatch();
            SA_time.Start();
            List<Job>[] _schedule = scheduling.GenerateNewSchedule(_units, _jobs);
            List<Job>[] SA_schedule = SimulatedAnneling.SA_schedule(scheduling.CostFunction, _units, _schedule);
            SA_time.Stop();

            Console.WriteLine("SA - czas funkcji:\t" + SA_time.ElapsedMilliseconds +"ms");
            DrawSchedule(SA_schedule, _units);

            Stopwatch GAF_time = new Stopwatch();
            GAF_time.Start();
            Genetic genetic_schedule = new Genetic(_jobs, _units);
            List<Job>[] GAF_schedule = genetic_schedule.FindBestSchedule();
            GAF_time.Stop();

            Console.WriteLine("Genetic - czas funkcji:\t" + GAF_time.ElapsedMilliseconds + "ms");
            DrawSchedule(GAF_schedule, _units);

            //Console.WriteLine(scheduling.CostFunction(SA_schedule, _units));
            //Console.WriteLine(scheduling.CostFunction(genetic_schedule.FindBestSchedule(), _units));

        }
    }
}
