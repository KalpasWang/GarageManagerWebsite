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
            price = new double();

            foreach (var purchase in ordersList)
            {
                Product product = model.GetOneProduct(purchase.ProductId);

                ImageButton imageButton = new ImageButton
                {
                    ImageUrl = "../Images/Products/" + product.Image,
                    PostBackUrl = "~/Page/Details.aspx?id=" + product.Id,
                    Width = 50
                };

                LinkButton linkDelete = new LinkButton
                {
                    ID = "del" + purchase.Id,
                    Text = "Delete",
                    ForeColor = System.Drawing.Color.Red
                };
                linkDelete.Click += linkDelete_DeleteItem;

                var range = Enumerable.Range(1, 10);
                DropDownList ddlAmount = new DropDownList
                {
                    ID = purchase.Id.ToString(),
                    AutoPostBack = true,
                    DataSource = range
                };

                ddlAmount.DataBind();
                ddlAmount.SelectedValue = purchase.Amount.ToString();
                ddlAmount.SelectedIndexChanged += ddlAmount_SelectedIndexChanged;

                Table cartTable = new Table { CssClass = "cartTable" };
                TableRow rowA = new TableRow();
                TableRow rowB = new TableRow();

                TableCell cellA1 = new TableCell { RowSpan = 2, Width = 50 };
                TableCell cellA2 = new TableCell { Text = $"<h4>{product.Name}</h4><br/>Product ID: {product.Id}<br/>In Stock" };
                TableCell cellA3 = new TableCell { Text = "Unit Price:<hr>" };
                TableCell cellA4 = new TableCell { Text = "Amount:<hr>" };
                TableCell cellA5 = new TableCell { Text = "Total:<hr>" };
                TableCell cellA6 = new TableCell { RowSpan = 2 };

                TableCell cellB1 = new TableCell();
                TableCell cellB2 = new TableCell { Text = string.Format("{0:c}", product.Price) };
                TableCell cellB3 = new TableCell();
                TableCell cellB4 = new TableCell { Text = string.Format("{0:c2}", product.Price*purchase.Amount) };

                cellA1.Controls.Add(imageButton);
                cellB3.Controls.Add(ddlAmount);
                cellA6.Controls.Add(linkDelete);

                rowA.Controls.Add(cellA1);
                rowA.Controls.Add(cellA2);
                rowA.Controls.Add(cellA3);
                rowA.Controls.Add(cellA4);
                rowA.Controls.Add(cellA5);
                rowA.Controls.Add(cellA6);

                rowB.Controls.Add(cellB1);
                rowB.Controls.Add(cellB2);
                rowB.Controls.Add(cellB3);
                rowB.Controls.Add(cellB4);

                cartTable.Controls.Add(rowA);
                cartTable.Controls.Add(rowB);

                PanelCart.Controls.Add(cartTable);

                price += product.Price * purchase.Amount;
            }
            Session[User.Identity.GetUserId()] = ordersList;
        }

        private void ddlAmount_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropDownList ddl = sender as DropDownList;
                PurchaseModel model = new PurchaseModel();

                model.UpdataAmount(Convert.ToInt32(ddl.ID), Convert.ToInt32(ddl.SelectedValue));
            }
            catch (Exception ex)
            {
                LabelError.Text = ex.ToString();
            }
        }

        private void linkDelete_DeleteItem(object sender, EventArgs e)
        {
            LinkButton button = sender as LinkButton;
            int purchaseId = Convert.ToInt32(button.ID.Replace("del", string.Empty));

            PurchaseModel model = new PurchaseModel();
            model.DeletePurchase(purchaseId);
        }
    }
}