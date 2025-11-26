using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSE445PublicLibrary
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //look for login cookie

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            //search service
            Response.Redirect("http://webstrar20.fulton.asu.edu/page0/SearchPage.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            //memberpage
            Response.Redirect("http://webstrar20.fulton.asu.edu/page4/MemberPage.aspx");

        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            //staff page
            Response.Redirect("Staff/StaffPage.aspx");
        }

        
        protected void Button4_Click(object sender, EventArgs e)
        {
            //login page
            Response.Redirect("http://webstrar20.fulton.asu.edu/page0/Login.aspx");
        }
        protected void Button5_Click(object sender, EventArgs e)
        {

            //register page
            Response.Redirect("http://webstrar20.fulton.asu.edu/page0/Registration.aspx");
        }

    }
}