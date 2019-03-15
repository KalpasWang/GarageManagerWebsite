using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using GarageManagerWebsite.Models;
using GarageManagerWebsite.Entities;

namespace GarageManagerWebsite.Page
{
    public partial class ManageProduct : System.Web.UI.Page
    {
        //private int _id = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                try
                {
                    BindImagesToDDL(DropDownListImage);

                    if(!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
                    {
                        int id = Convert.ToInt32(Request.QueryString["id"]);
                        FillPageWithExistedProduct(id);
                    }
                }
                catch (Exception ex)
                {
                    LabelResult.Text = ex.Message + "\n" + ex.StackTrace;
                }

            }
        }

        private void BindImagesToDDL(DropDownList DropDownListImage)
        {
            DropDownListImage.DataSource = GetImagesFileName();
            DropDownListImage.AppendDataBoundItems = true;
            DropDownListImage.DataBind();
        }

        private List<string> GetImagesFileName()
        {
            string[] imagesPath = Directory.GetFiles(Server.MapPath("~/Images/Products/"));
            List<string> imagesFileName = new List<string>();
            foreach(string imagePath in imagesPath)
            {
                string imageName = imagePath.Substring(imagePath.LastIndexOf(@"\") + 1);
                imagesFileName.Add(imageName);
            }
            return imagesFileName;
        }

        private void FillPageWithExistedProduct(int id)
        {
            //int id = Convert.ToInt32(Request.QueryString["id"]);
            if (id >= 0)
            {
                ProductModel model = new ProductModel();
                Product product = model.GetOneProduct(id);

                TextBoxDescription.Text = product.Description;
                TextBoxName.Text = product.Name;
                TextBoxPrice.Text = product.Price.ToString();
                DropDownListProductType.SelectedValue = product.TypeId.ToString();
                DropDownListImage.SelectedValue = product.Image;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                try
                {
                    ProductModel model = new ProductModel();
                    Product product = CreateProduct();
                    if (int.TryParse(Request.QueryString["id"], out int id))
                    {
                        if (id > 0)
                        {
                            Response.Write("<script>alert('" + model.UpdateProduct(id, product) +
                                "'); window.location='Management.aspx';</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('" + model.AddProduct(product) +
                            "'); window.location='Management.aspx';</script>");
                    }
                }
                catch(Exception ex)
                {
                    LabelResult.Text = ex.Source + "\n" + ex.Message;
                }
            }
        }

        private Product CreateProduct()
        {
            Product product = new Product
            {
                Name = TextBoxName.Text,
                Price = Convert.ToInt32(TextBoxPrice.Text),
                TypeId = Convert.ToInt32(DropDownListProductType.SelectedValue),
                Image = DropDownListImage.SelectedValue,
                Description = TextBoxDescription.Text
            };

            return product;
        }
    }
}