using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace CSE445PublicLibrary.Staff
{
    public partial class StaffPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addButton_Click(object sender, EventArgs e)
        {

            string localFile = Server.MapPath("~/App_Data/Inventory.xml");

            string url = "http://webstrar20.fulton.asu.edu/page10/Inventory.xml";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(url);

            // Create new element
            XmlElement item = xmlDoc.CreateElement("Book");
     

            XmlElement title = xmlDoc.CreateElement("Title");
            title.InnerText = TitleBox.Text;
            item.AppendChild(title);

            XmlElement author = xmlDoc.CreateElement("Author");
            author.InnerText = authorBox.Text;
            item.AppendChild(author);

            // Append to root
            xmlDoc.DocumentElement.AppendChild(item);

            // Save locally (or back to server if supported)
            xmlDoc.Save(localFile);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://webstrar20.fulton.asu.edu/page0/Default.aspx");
        }
    }
}