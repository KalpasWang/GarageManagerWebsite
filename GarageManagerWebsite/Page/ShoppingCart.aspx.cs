using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using GarageManagerWebsite.Models;
using GarageManagerWebsite.Entities;

namespace GarageManagerWebsite.Page
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string userId = User.Identity.GetUserId();
                GetPurchasesListInCart(userId);
            }
        }

        private void GetPurchasesListInCart(string userId)
        {
            try
            {
                PurchaseModel model = new PurchaseModel();
                var ordersList = model.GetOrdersInCart(userId);
                LayoutProductsTable(ordersList, out double price);

                double vat = Math.Round(price * 0.21, 2);
                const double shipping = 15;
                double totalAmount = price + vat + shipping;

                LiteralPrice.Text = string.Format("{0:c}", price);
                LiteralVAT.Text = string.Format("{0:c}", vat);
                LiteralShipping.Text = string.Format("{0:c}", shipping);
                LiteralTotal.Text = string.Format("{0:c}", totalAmount);

            }
            catch (Exception ex)
            {
                LabelError.Text = ex.ToString();
            }
        }

        private void LayoutProductsTable(List<Purchase> ordersList, out double price)
        {
            ProductModel model = new ProductModel();

            foreach (var purchase in ordersList)
            {
                Product product = model.GetOneProduct(purchase.ProductId);

                ImageButton imageButton = new ImageButton
                {
                    ImageUrl = product.Image,
                    PostBackUrl = "~/Page/Details.aspx?id=" + product.Id
                };
            }
        }
    }
}