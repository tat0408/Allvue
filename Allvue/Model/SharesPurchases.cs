using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allvue.Model
{
    public class SharesPurchases
    {
        public int Shares { get; set; }
        public decimal PricePerShare { get; set; }

        public SharesPurchases(int shares, decimal pricePerShare)
        {
            Shares = shares;
            PricePerShare = pricePerShare;
        }
    }
}
