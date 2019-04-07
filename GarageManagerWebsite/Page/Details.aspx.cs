using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GarageManagerWebsite.Models;
using GarageManagerWebsite.Entities;
using Microsoft.AspNet.Identity;

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
            try
            {
                ProductModel model = new ProductModel();
                Product product = model.GetOneProduct(id);

                lblProductID.Text = product.Id.ToString();
                lblTitle.Text = product.Name;
                imgProduct.ImageUrl = "~/Images/Products/" + product.Image;
                lblDescription.Text = product.Description;
                lblPrice.Text = string.Format(new System.Globalization.CultureInfo("zh-TW"), "{0:c}", product.Price);

                int[] amount = Enumerable.Range(1, 10).ToArray();
                ddlAmount.DataSource = amount;
                ddlAmount.DataBind();
            }
            catch(Exception)
            {
                Response.Write("Can not find the product!");
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if(!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
                {                   
                    string clientId = User.Identity.GetUserId();

                    if (clientId != null)
                    {
                        int productId = Convert.ToInt32(Request.QueryString["id"]);
                        int amount = Convert.ToInt32(ddlAmount.SelectedValue);

                        Purchase newPurchase = new Purchase
                        {
                            CustomerId = clientId,
                            ProductId = productId,
                            Amount = amount,
                            DatePurchased = DateTime.Now,
                            IsInCart = true
                        };

                        PurchaseModel model = new PurchaseModel();
                        LabelResult.Text = model.AddPurchase(newPurchase);
                    }
                    else
                    {
                        Response.Redirect("~/Page/Account/login.aspx");
                    }
                }

            }
            catch (Exception)
            {
                LabelResult.Text = "Purchase Fail";
                LabelResult.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}