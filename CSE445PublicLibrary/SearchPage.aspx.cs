using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;


namespace CSE445PublicLibrary
{
    public partial class SearchPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void SearchButton_Click(object sender, EventArgs e)
        {
            //send REST call to bookSearchService
            string url = "http://webstrar20.fulton.asu.edu/page2/bookSearchService.svc/SearchBook?keyword=" + KeywordBox.Text;
            string result = await CallRestServiceAsync(url);


            try
            {
                var serializer = new JavaScriptSerializer();
                List<XmlSearch.XmlSearch.Book> books = serializer.Deserialize<List<XmlSearch.XmlSearch.Book>>(result);

                StringBuilder sb = new StringBuilder();

                //build a nice output to display to users
                foreach (var book in books)
                {
                    sb.AppendLine($"Title: {book.Title}");
                    sb.AppendLine($"Author: {book.Author}");
                    sb.AppendLine("-------------------");
                }

                Label4.Text = sb.ToString().Replace("\n", "<br/>");
            }
            catch (Exception ex)
            {
                // Fallback if result is not JSON
                Label4.Text = "Raw: " + result  + " ~~~~~~~~~~~~~~"+ ex.Message;
            }
        }

        //helper function for book search.
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


        protected void ReturnButton_Click1(object sender, EventArgs e)
        {
            Response.Redirect("http://webstrar20.fulton.asu.edu/page0/Default.aspx");
        }
    }
}