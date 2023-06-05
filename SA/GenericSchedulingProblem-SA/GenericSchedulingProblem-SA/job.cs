using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSchedulingProblem_SA
{
    public class Job
    {
        public int Id { get; set; }
        public int Time { get; set; }
        public int? PrevJob { get; set; }

        public int Unit { get; set; }

        public Job(int id, int time, int? prevJob = null)
        {
            Id = id;
            Time = time;
            PrevJob = prevJob;
        }
    }
}
