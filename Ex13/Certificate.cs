using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex13
{
    public class Certificate
    {
        public int Id { get; set; }
        public string CertificateName { get; set; }
        public int Rank { get; set; }
        public DateTime Date { get; set; }

        public Certificate(int id, string certificateName, int rank, DateTime date)
        {
            Id = id;
            CertificateName = certificateName;
            Rank = rank;
            Date = date;
        }
    }
}
