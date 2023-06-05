using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSchedulingProblem_SA
{
    public static class SimulatedAnneling
    {


        static double P(double fs, double fs_next, double T)
        {
            double delta = fs_next - fs;
            if (delta < 0) return 1;
            else return (double)Math.Exp(-delta / T);
        }

        public static List<Job>[] SA_schedule(Func<List<Job>[], int, double> f, int num_units, List<Job>[] s0)
        {
            List<Job>[] s_best = s0;
            double T = 100;
            double Tmin = 0.001;
            List<Job>[] s_next;
            double cooling = 0.96;
            Random random = new Random();

            while (T > Tmin)
            {
                for (int i = 0; i <= 100; i++)
                {
                    s_next = scheduling.NeighbourSchedule(s_best, random, num_units);
                    double chance = P(f(s_best, num_units), f(s_next, num_units), T);
                    if (chance == 1 || chance > random.NextDouble()) s_best = s_next;
                }
                T *= cooling;
            }

            return s_best;
        }
    }
}
