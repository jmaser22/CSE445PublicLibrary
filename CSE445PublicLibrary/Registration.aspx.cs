using LibrarySecurityDLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSE445PublicLibrary
{
    public partial class Registration : System.Web.UI.Page
    {

        string serviceUrl = ConfigurationManager.AppSettings["ServiceUrl"];
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RgstrBtn_Click(object sender, EventArgs e)
        {
            //Verify fields are filled out:

            if (usernameBox.Text == "" || passwordBox.Text == "") { ErrorLabel.Text = "Please enter username and password"; ErrorLabel.Visible = true; return; }



            //need to call the Register REST Api to create a new account, if not success then user must re enter new username
            string role = "Member";
            if (IsStaff.Checked) role = "Staff";
            string HashedPassword = LibrarySecurity.Hash(passwordBox.Text);
            string site = serviceUrl + $"/RegisterNewUser?username={usernameBox.Text}&HashedPassword={HashedPassword}&role={role}";

            string response = "";
            using (var client = new HttpClient())
            {
                response = client.GetStringAsync(site).Result;
            }
            response = response
              .Replace("</string>", "")
              .Replace("<string xmlns=\"http://tempuri.org/\">", "")
              .Trim();

            if (response.Contains("Success")) //user added succesfully
            {
                //go back to the default try it page for them to login with credentials
                GoBack.Visible = true;
                ErrorLabel.Visible = false;
                RegisterBtn.Enabled = false;
            }
            else
            {
                //account username is taken, so the user needs to register under a different username
                ErrorLabel.Visible = true;
                ErrorLabel.Text = "Username is already in use, please try again";

            }
        }

        protected void ReturnBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void IsStaff_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}