using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex15.Entity
{
    internal class Result
    {
        public int ResultId { get; set; }
        public double Score { get; set; }
        public int Semester { get; set; }
        public int StudentId { get; set; }
        public Result()
        {
        }

        public Result(int resultId, double score, int semester, int studentId)
        {
            ResultId = resultId;
            Score = score;
            Semester = semester;
            StudentId = studentId;
        }
    }
}
