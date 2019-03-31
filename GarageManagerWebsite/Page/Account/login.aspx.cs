using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Configuration;

namespace GarageManagerWebsite.Page.Account
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var userStore = new UserStore<IdentityUser>();
            userStore.Context.Database.Connection.ConnectionString =
                ConfigurationManager.ConnectionStrings["GarageDBConnectionString"].ConnectionString;

            var userManager = new UserManager<IdentityUser>(userStore);

            var user = userManager.Find(TextBoxName.Text, TextBoxPassword.Text);

            if(user != null)
            {
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                authenticationManager.SignIn(new AuthenticationProperties
                {
                    IsPersistent = false
                }, userIdentity);

                Response.Redirect("~/Page/index.aspx");
            }
            else
            {
                LabelResult.Text = "Invalid user name or password";
            }
        }
    }
}