using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GarageManagerWebsite.Models;
using GarageManagerWebsite.Entities;

namespace GarageManagerWebsite.Page
{
    public partial class Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                FillPageWithProductId(id);
            }
        }

        private void FillPageWithProductId(int id)
        {
            ProductModel model = new ProductModel();
            Product product = model.GetOneProduct(id);

            lblProductID.Text = product.Id.ToString();
            lblTitle.Text = product.Name;
            imgProduct.ImageUrl = "~/Images/Products/" + product.Image;
            lblDescription.Text = product.Description;
            lblPrice.Text = "Price: " + string.Format(new System.Globalization.CultureInfo("zh-TW"), "{0:c}", product.Price);

            int[] amount = Enumerable.Range(1, 10).ToArray();
            ddlAmount.DataSource = amount;
            ddlAmount.DataBind();
        }
    }
}