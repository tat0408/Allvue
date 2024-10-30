using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Allvue.Model;
using Allvue.BL;
using Allvue.DL;

namespace Allvue.BL
{
    public class Calculator
    {
        private readonly List<SharesPurchases> _purchaseLots;

        public Calculator()
        {
            Data data = new Data();
            _purchaseLots = data.GetPurchaseLots();
        }

        public Result CalculateFIFO(int sharesToSell, decimal salePricePerShare)
        {
            int totalRemainingShares = 0;
            decimal soldCost = 0;
            decimal remainingCost = 0;
            decimal profit = 0;
            int sharesSold = sharesToSell;

            foreach (var lot in _purchaseLots)
            {
                if (sharesSold <= 0) break;

                int lotSharesToSell = Math.Min(sharesSold, lot.Shares);
                decimal lotCostBasis = lotSharesToSell * lot.PricePerShare;
                soldCost += lotCostBasis;
                profit += lotSharesToSell * (salePricePerShare - lot.PricePerShare);
                sharesSold -= lotSharesToSell;
                lot.Shares -= lotSharesToSell;
            }

            foreach (var lot in _purchaseLots)
            {
                totalRemainingShares += lot.Shares;
                remainingCost += lot.Shares * lot.PricePerShare;
            }
            Result myResult = new Result();
            myResult.remainingShares=totalRemainingShares;
            myResult.soldCostBasis= Math.Round(soldCost / sharesToSell,2);
            myResult.remainingCostBasis= totalRemainingShares > 0 ? Math.Round(remainingCost / totalRemainingShares,2) : 0;
            myResult.profit = profit;            
            return myResult ;
        }
    }
}