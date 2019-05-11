using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using GarageManagerWebsite.Entities;
using GarageManagerWebsite.Models;

namespace GarageManagerWebsite.Page
{
    public partial class PurchaseSuccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.PreviousPage != null)
            {
                try
                {
                    Label label = new Label
                    {
                        Text = "Your purchase is successful, the total price is" + Request.Form["LiteralTotal"]
                    };
                    Panel1.Controls.Add(label);

                    var cart = Session[User.Identity.GetUserId()] as List<Purchase>;
                    PurchaseModel model = new PurchaseModel();
                    model.MarkOrdersAsPaid(cart);

                    Session[User.Identity.GetUserId()] = null;
                }
                catch (Exception ex)
                {
                    Literal1.Text = ex.ToString();
                }
            }
        }
    }
}