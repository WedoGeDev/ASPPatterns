using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPPatterns.Chap3.Layered.Model;
using ASPPatterns.Chap3.Layered.Presentation;
using ASPPatterns.Chap3.Layered.Service;
using StructureMap;

namespace ASPPatterns.Chap3.Layered.WebUI
{
    public partial class Default : System.Web.UI.Page, IProductListView
    {
        private ProductListPresenter _presenter;
        public CustomerType CustomerType
        {
            get => (CustomerType)Enum
                .ToObject(typeof(CustomerType), int.Parse(ddlCustomerType.SelectedValue));
        }

        public string ErrorMessage { set => lblErrorMessage.Text = $@"
            <p>
                <strong>Error</error><br />
                {value}
            </p>
        "; }

        public void Display(IList<ProductViewModel> products)
        {
            rptProducts.DataSource = products;
            rptProducts.DataBind();
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            _presenter = new ProductListPresenter(this, ObjectFactory.GetInstance<Service.ProductService>());
            ddlCustomerType.SelectedIndexChanged += delegate { _presenter.Display(); };
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                _presenter.Display();
        }
    }
}