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
    public partial class ManageProductType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    ProductTypeModel model = new ProductTypeModel();
                    ProductType newProductType = CreateProductType(TextBoxName.Text);

                    LabelResult.Text = model.AddProductType(newProductType);
                    LabelResult.ForeColor = System.Drawing.Color.Green;
                    TextBoxName.Text = string.Empty;
                }
                catch(Exception ex)
                {
                    LabelResult.Text = ex.StackTrace + "\n" + ex.Message; 
                    LabelResult.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            { LabelResult.Text = "The input is not valid"; }
        }

        private ProductType CreateProductType(string name)
        {
            ProductType productType = new ProductType
            {
                Name = name
            };
            return productType;
        }
    }
}