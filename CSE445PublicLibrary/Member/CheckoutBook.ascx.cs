using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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

        protected async void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string baseUrl = "http://webstrar20.fulton.asu.edu/page6/CheckoutService.svc";
                string title = titleEntry.Text;
                string url = baseUrl + $"/CheckoutBook?title={title}";

                //Creating client and getting result
                WebClient webClient = new WebClient();

                string result = await CallRestServiceAsync(url);


               // string result = webClient.DownloadString(url);
                bool success = result.Contains("true");

                if (success)
                {
                    Label1.Text = "You have successfully checked out: " + title;
                }
                else
                {
                    Label1.Text = "Failure to checkout: " + title;
                }


            }
            catch (WebException ex)
            {
                // Show the URL and error message
               Label1.Text = $"Error accessing URL: {ex.Message}";
            }


            
        }
        public async Task<string> CallRestServiceAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {

                    // Send GET request
                    HttpResponseMessage response = await client.GetAsync(url);

                    response.EnsureSuccessStatusCode(); // Throws if not 2xx

                    // Read response as string
                    string responseBody = await response.Content.ReadAsStringAsync();

                    return responseBody;
                }
                catch (Exception ex)
                {
                    // Handle errors
                    return $"Error: {ex.Message}";
                }
            }
        }

    }
}