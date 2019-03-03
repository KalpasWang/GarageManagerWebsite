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
                    Panel panelProduct = new Panel();
                    ImageButton imageButton = new ImageButton
                    {
                        ImageUrl = "~/Images/Products/" + product.Image,
                        CssClass = "productImage",
                        PostBackUrl = "~/Page/Product.aspx?id=" + product.Id
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

                    panelProduct.Controls.Add(imageButton);
                    panelProduct.Controls.Add(new Literal { Text = "<br/>" });
                    panelProduct.Controls.Add(labelName);
                    panelProduct.Controls.Add(new Literal { Text = "<br/>" });
                    panelProduct.Controls.Add(labelPrice);


                    PanelAllProducts.Controls.Add(panelProduct);
                }
            }
        }
    }
}