using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GarageManagerWebsite
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var userIdentity = Context.User.Identity;
            if(userIdentity.IsAuthenticated)
            {
                LiteralUserName.Text = userIdentity.Name;

                LinkButtonLogOut.Visible = true;
                LiteralUserName.Visible = true;

                HyperLinkLogin.Visible = false;
                HyperLinkRegister.Visible = false;
            }
            else
            {
                LinkButtonLogOut.Visible = false;
                LiteralUserName.Visible = false;

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