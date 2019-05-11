using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GarageManagerWebsite.Models;

namespace GarageManagerWebsite.Page
{
    public partial class Management : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = GridViewProducts.Rows[e.NewEditIndex];
            Response.Redirect("~/Page/ManageProduct.aspx?id=" + row.Cells[2].Text);
        }

        protected void GridViewProducts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ProductTypeModel model = new ProductTypeModel();
                    int id = Convert.ToInt32(e.Row.Cells[4].Text);
                    e.Row.Cells[5].Text = model.GetProductTypeById(id).Name;
                }
            }
            catch (Exception ex)
            {
                LabelError.Text = ex.StackTrace + "\n" + ex.Message;
             
            }
        }
    }
}