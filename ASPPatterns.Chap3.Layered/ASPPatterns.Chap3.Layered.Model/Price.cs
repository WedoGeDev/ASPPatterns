using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPPatterns.Chap3.Layered.Model
{
    public class Price
    {
        private IDiscountStrategy _discountStrategy = new NullDiscountStrategy();
        private decimal _sellingPrice;
        public decimal RPP { get; private set; }

        public Price(decimal rpp, decimal sellingPrice)
        {
            RPP = rpp;
            _sellingPrice = sellingPrice;
        }

        public void SetDiscountStrategyTo(IDiscountStrategy discountStrategy)
        {
            _discountStrategy = discountStrategy;
        }

        public decimal SellingPrice
        {
            get { return _discountStrategy.ApplyExtraDiscountsTo(_sellingPrice); }
        }

        public decimal Discount
        {
            get
            {
                if (RPP > SellingPrice)
                {
                    return (RPP - SellingPrice);
                }
                else
                {
                    return 0;
                }
            }
        }

        public decimal Savings
        {
            get
            {
                if (RPP > SellingPrice)
                {
                    return 1 - (SellingPrice / RPP);
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
