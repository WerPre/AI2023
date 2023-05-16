using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSchedulingProblem_SA
{
    public class scheduling
    {
        static public int[] GenerateNewSchedule(int num_jobs, int num_units, List<Dictionary<string, int?>> jobs)
        {
            List<int> units = Enumerable.Range(0, num_units).ToList();
            int[] schedule = Enumerable.Repeat(-1, num_jobs).ToArray();
            Random rand = new Random();

            for (int i = 0; i < num_jobs; i++)
            {
                List<Dictionary<string, int?>> job_dependencies = jobs.Where(j => j["dependency"] == i).ToList();
                int? latest_unit;
                if (job_dependencies.Count > 0)
                {
                    job_dependencies = job_dependencies.OrderBy(j => schedule[j["id"]]).ToList();
                    var latest_dependency = job_dependencies.Last();
                    latest_unit = schedule[latest_dependency["id"]];
                    units.Remove(latest_unit);
                }
                else
                {
                    latest_unit = -1;
                }
                if (units.Count == 0)
                {
                    return null;
                }
                int new_unit = units[rand.Next(units.Count)];
                units.Remove(new_unit);
                schedule[i] = new_unit;
                if (latest_unit != -1)
                {
                    units.Add(latest_unit);
                }
            }
            return schedule;

        }

        public static int CostFunction(int[] schedule, List<Dictionary<string, int>> jobs)
        {
            int n = schedule.Length;
            int[] durations = jobs.Select(j => j["duration"]).ToArray();
            int[] dependencies = jobs.Select(j => j["dependency"]).ToArray();
            int total_cost = 0;
            int[] time_by_unit = new int[new HashSet<int>(schedule).Count];
            for (int i = 0; i < n; i++)
            {
                int unit = schedule[i];
                int time = time_by_unit[unit];
                if (dependencies[i] != -1)
                {
                    int dep_unit = schedule[dependencies[i]];
                    int dep_time = time_by_unit[dep_unit] + durations[dependencies[i]];
                    if (dep_time > time)
                    {
                        time = dep_time;
                    }
                }
                int cost = Math.Abs(time - time_by_unit[unit]) + durations[i];
                time_by_unit[unit] = time + durations[i];
                total_cost += cost;
            }
            return total_cost;
        }
    }
}
