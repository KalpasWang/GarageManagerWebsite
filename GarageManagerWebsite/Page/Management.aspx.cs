using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
    }
}