using LibrarySecurityDLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSE445PublicLibrary
{
    public partial class Login : System.Web.UI.Page
    {
        string serviceUrl = ConfigurationManager.AppSettings["ServiceUrl"];
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            //This method verifies users are who they say they are
            //Then gives them an authentication cookie to store over the browser
            //then they are sent back to the default page to then click on a 
            string HashPassword = LibrarySecurity.Hash(passwordBox.Text);

            string site = serviceUrl + $"/LoginAuth?username={usernameBox.Text}&HashedPassword={HashPassword}";
            string response = "";
            using (var client = new HttpClient())
            {
                response = client.GetStringAsync(site).Result;
            }
            ErrorLabel.Text = "Error, " + response; ErrorLabel.Visible = true;
            //should get a message back like: "password,Staff"
            response = response
                .Replace("</string>", "")
                .Replace("<string xmlns=\"http://tempuri.org/\">", "")

                .Trim();
            string role = response;

            if (response.Contains("Staff"))
            {
                role = "Staff";
            }
            else if (response.Contains("Member"))
            {
                role = "Member";
            }


            //If login is succesful create cookie, response should be their role
            if (role == "Staff" || role == "Member")
            {
                //FormsAuthentication.RedirectFromLoginPage(usernameBox.Text, IsPersistent.Checked);
                //setup authCookies

                var ticket = new FormsAuthenticationTicket(
                    1,
                    usernameBox.Text,
                    DateTime.Now,
                    DateTime.Now.AddMinutes(30),
                    IsPersistent.Checked,
                    role
                    );

                string encrypted = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);

                Response.Cookies.Add(cookie);
                Response.Redirect("Default.aspx");

            }
            else { ErrorLabel.Text = "Error, " + role; ErrorLabel.Visible = true; }


        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }

        protected void IsPersistent_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}