using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace GenericSchedulingProblem_SA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int _units = 3;
            Job[] _jobs = { new Job(0, 20), new Job(1, 30, 0), new Job(2, 12), new Job(3, 11) };
            
            List<Job>[] _schedule = scheduling.GenerateNewSchedule(_units, _jobs);
            
            Console.WriteLine(scheduling.CostFunction(_schedule, _units));

            List<Job>[] SA_schedule = SimulatedAnneling.SA_schedule(scheduling.CostFunction, _units, _schedule, (Job[])_jobs.Clone());
            Genetic genetic_schedule = new Genetic((Job[])_jobs.Clone(), _units);
            Console.WriteLine(scheduling.CostFunction(SA_schedule, _units));
            Console.WriteLine(scheduling.CostFunction(genetic_schedule.FindBestSchedule(), _units));

        }
    }
}
