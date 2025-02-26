using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPPatterns.Chap3.Layered.Model
{
    public interface IDiscountStrategy
    {
        decimal ApplyExtraDiscountsTo(decimal OriginalSalesPrice);
    }

    public class TradeDiscountStrategy : IDiscountStrategy
    {
        public decimal ApplyExtraDiscountsTo(decimal OriginalSalesPrice)
        {
            var price = OriginalSalesPrice;
            price *= 0.95M;
            return price;
        }
    }

    public class NullDiscountStrategy : IDiscountStrategy
    {
        public decimal ApplyExtraDiscountsTo(decimal OriginalSalesPrice)
        {
            return OriginalSalesPrice;
        }
    }
}
