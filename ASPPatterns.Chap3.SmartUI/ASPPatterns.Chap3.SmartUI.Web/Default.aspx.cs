using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var RRP = decimal.Parse(((DataRowView)e.Row.DataItem)["RRP"].ToString());
            var SellingPrice = decimal.Parse(((DataRowView)e.Row.DataItem)["SellingPrice"].ToString());

            var lblSavings = (Label)e.Row.FindControl("lblSavings");
            var lblDiscount = (Label)e.Row.FindControl("lblDiscount");
            var lblSellingPrice = (Label)e.Row.FindControl("lblSellingPrice");

            lblSavings.Text = DisplaySavings(RRP, 
                ApplyExtraDiscountTo(SellingPrice));
            lblDiscount.Text = DisplayDiscount(RRP,
                ApplyExtraDiscountTo(SellingPrice));
            lblSellingPrice.Text = string.Format("{0:C}",
                ApplyExtraDiscountTo(SellingPrice));
        }
    }

    private string DisplayDiscount(decimal RRP, decimal sellingPrice)
    {
        var discountText = string.Empty;
        if (RRP > sellingPrice)
        {
            discountText = string.Format("{0:C}", (RRP - sellingPrice));
        }
        return discountText;
    }

    private string DisplaySavings(decimal RRP, decimal sellingPrice)
    {
        var savingsText = string.Empty;
        if (RRP > sellingPrice)
        {
            savingsText = (1 - (sellingPrice / RRP)).ToString("#%");
        }
        return savingsText;
    }

    protected decimal ApplyExtraDiscountTo(decimal OriginalSalePrice)
    {
        decimal price = OriginalSalePrice;
        var discountType = Int16.Parse(ddlDiscountType.SelectedValue);
        if (discountType == 1)
        {
            price *= 0.95M;
        }

        return price;
    }

    protected void ddlDiscountType_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.DataBind();
    }
}