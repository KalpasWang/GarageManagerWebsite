using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GarageManagerWebsite.Models;
using Microsoft.AspNet.Identity;

namespace GarageManagerWebsite
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var userIdentity = Context.User.Identity;
            if(userIdentity.IsAuthenticated)
            {
                //LiteralUserName.Text = userIdentity.Name;

                LinkButtonLogOut.Visible = true;
                //LiteralUserName.Visible = true;
                HyperLinkUserName.Visible = true;

                HyperLinkLogin.Visible = false;
                HyperLinkRegister.Visible = false;

                PurchaseModel model = new PurchaseModel();
                int amount = model.GetAmountOfOrders(userIdentity.GetUserId());
                HyperLinkUserName.Text = userIdentity.Name + $"({amount})";

            }
            else
            {
                LinkButtonLogOut.Visible = false;
                //LiteralUserName.Visible = false;
                HyperLinkUserName.Visible = false;

                HyperLinkLogin.Visible = true;
                HyperLinkRegister.Visible = true;
            }
        }

        protected void LinkButtonLogOut_Click(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            Response.Redirect("~/Page/index.aspx");
        }
    }
}