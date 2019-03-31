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
    public partial class register : System.Web.UI.Page
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

            //Create new user and try to store in DB.
            var user = new IdentityUser { UserName = TextBoxName.Text };

            if(TextBoxPassword.Text == TextBoxConfirm.Text)
            {
                try
                {
                    IdentityResult result = userManager.Create(user, TextBoxPassword.Text);
                    if(result.Succeeded)
                    {
                        var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                        
                        // store user in DB
                        var claimsIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                        // log in new user and set a cookie then redirect 
                        authenticationManager.SignIn(new AuthenticationProperties(), claimsIdentity);
                        Response.Redirect("~/Page/index.aspx");
                    }
                    else
                    {
                        LiteralResult.Text = result.Errors.FirstOrDefault();
                    }
                }
                catch(Exception ex)
                {
                    LiteralResult.Text = ex.ToString();
                }
            }
            else
            {
                LiteralResult.Text = "Passwords must match";
            }

        }
    }
}