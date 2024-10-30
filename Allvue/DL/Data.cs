using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Allvue.Model;

namespace Allvue.DL
{
    public class Data
    {
        public List<SharesPurchases> GetPurchaseLots()
        {
            return new List<SharesPurchases>
        {
            new SharesPurchases(100, 20),
            new SharesPurchases(150, 30),
            new SharesPurchases(120, 10)
        };
        }
    }
}
