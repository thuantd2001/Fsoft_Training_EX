using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex4
{
    public class Family
    {
        public Family()
        {
        }

        public Family(int homeId, List<Member> members)
        {
            HomeId = homeId;
        
            Members = members;
        }

        public int HomeId { get; set; }
        public int NumberOfMember { get; set; }
        List<Member> Members { get; set; }

        public override string? ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"HomeId-{HomeId}; NumberOfMember-{Members.Count()}; ");
            if(Members.Count > 0)
            {
                foreach (Member m in Members)
                {
                    sb.Append("\n \t - Member: "+m);
                }
            }
            return sb.ToString();
        }
    }
}
