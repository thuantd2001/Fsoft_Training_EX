using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex15.Entity
{
    internal class LearningOutcome
    {
       
        public double Score { get; set; }
        public int Semester { get; set; }
        public string StudentId { get; set; }
        public LearningOutcome()
        {
        }

        public LearningOutcome( double score, int semester, string studentId)
        {
            StudentId = studentId;
            Score = score;
            Semester = semester;
        }
    }
}
