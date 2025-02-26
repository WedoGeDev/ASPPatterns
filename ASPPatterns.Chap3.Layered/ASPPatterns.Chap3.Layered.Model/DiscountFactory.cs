using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPPatterns.Chap3.Layered.Model
{
    public static class DiscountFactory
    {
        public static IDiscountStrategy GetDiscountStrategyFor(CustoperType customerType)
        {
            switch (customerType)
            {
                case CustoperType.Trade:
                    return new TradeDiscountStrategy();
                default:
                    return new NullDiscountStrategy();
            }
        }
    }
}
