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
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillPageWithProducts();
        }

        private void FillPageWithProducts()
        {
            ProductModel model = new ProductModel();
            List<Product> products = model.GetAllProducts();

            if(products != null)
            {
                foreach(Product product in products)
                {
                    LinkButton linkButton = new LinkButton
                    {
                        CssClass="productContainer",
                        Text = "<div class='imageContainer'>" +
                               "<img class='productImage' src='../Images/Products/" + product.Image + "'/>" +
                               "<span class='productName'>" + product.Name + "</span><br/>" +
                               "<span class='productPrice'>" + string.Format("{0:c}", product.Price) + "</span>" +
                               "</div>",
                        PostBackUrl = "~/Page/Details.aspx?id=" + product.Id

                    };

                    PanelAllProducts.Controls.Add(linkButton);
                    /*
                    Panel panelProduct = new Panel
                    {
                        CssClass = "productContainer"
                    };
                    Panel panelImg = new Panel
                    {
                        CssClass = "imageContainer"
                    };
                    ImageButton imageButton = new ImageButton
                    {
                        ImageUrl = "~/Images/Products/" + product.Image,
                        CssClass = "productImage",
                        PostBackUrl = "~/Page/Details.aspx?id=" + product.Id
                    };
                    Label labelName = new Label
                    {
                        Text = product.Name,
                        CssClass = "productName"
                    };
                    Label labelPrice = new Label
                    {
                        Text = string.Format("{0:c}", product.Price),
                        CssClass = "productPrice"
                    };

                    panelImg.Controls.Add(imageButton);
                    panelProduct.Controls.Add(panelImg);
                    //panelProduct.Controls.Add(imageButton);
                    panelProduct.Controls.Add(new Literal { Text = "<br/>" });
                    panelProduct.Controls.Add(labelName);
                    panelProduct.Controls.Add(new Literal { Text = "<br/>" });
                    panelProduct.Controls.Add(labelPrice);


                    PanelAllProducts.Controls.Add(panelProduct);
                    */
                }
            }
        }
    }
}