using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSE445PublicLibrary
{
    public partial class CheckoutBook : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            CheckoutRef.CheckoutServiceClient prxy = new CheckoutRef.CheckoutServiceClient();
            string s = titleEntry.Text;
            bool success = prxy.CheckoutBook(s);

            /*CheckoutServiceClient prxy = new CheckoutServiceClient();
            string s = titleEntry.Text;
            bool success = prxy.CheckoutBook(s);*/

            /*CheckoutService.CheckoutService prxy = new CheckoutService.CheckoutService();
            string s = titleEntry.Text;
            bool success = prxy.CheckoutBook(s);*/

            if (success)
            {
                Label1.Text = "You have successfully checked out: " + s;
            }
            else
            {
                Label1.Text = "Failure to checkout: " + s;
            }
        }

    }
}