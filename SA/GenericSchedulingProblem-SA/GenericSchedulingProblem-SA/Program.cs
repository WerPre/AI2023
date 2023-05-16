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
            int units = 3;
            List <Dictionary<string, int?>> jobs = new List<Dictionary<string, int?>>();
            jobs.Add(new Dictionary<string, int?> { { "id", 0 }, { "duration", 5 }, { "dependency", null } } );
            jobs.Add(new Dictionary<string, int?> { { "id", 1 }, { "duration", 3 }, { "dependency", 0 } });
            jobs.Add(new Dictionary<string, int?> { { "id", 2 }, { "duration", 2 }, { "dependency", 1 } });
            scheduling.GenerateNewSchedule(3, units, jobs);
        }
    }
}
