using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allvue.Model
{
    public class Result
    {
        public int remainingShares { get; set; }
        public decimal soldCostBasis { get; set; }
        public decimal remainingCostBasis { get; set; }
        public decimal profit { get; set; }
    }
}
