using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace XmlSearch
{
    public class XmlSearch
    {
        public class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
        }

        public static List<Book> search(string url, string keyword)
        {
            // Download XML from URL
            string xmlContent = new System.Net.WebClient().DownloadString(url);

            // Load XML into XPathDocument
            using (StringReader sr = new StringReader(xmlContent))
            {
                XPathDocument doc = new XPathDocument(sr);
                XPathNavigator nav = doc.CreateNavigator();

                // XPath query for matching Author
                string xpath = $"/Books/Book[Author='{keyword}']";
                XPathNodeIterator nodes = nav.Select(xpath);

                List<Book> results = new List<Book>();

                while (nodes.MoveNext())
                {
                    var node = nodes.Current;

                    // add books to list
                    string title = node.SelectSingleNode("Title")?.Value ?? "";
                    string author = node.SelectSingleNode("Author")?.Value ?? "";

                    results.Add(new Book { Title = title, Author = author });
                }

                //xPath query for matching titles
                string xpathTitle = $"/Books/Book[Title='{keyword}']";
                XPathNodeIterator titleNodes = nav.Select(xpathTitle);

                while (titleNodes.MoveNext())
                {
                    var node = titleNodes.Current;

                    results.Add(new Book
                    {
                        Title = node.SelectSingleNode("Title")?.Value ?? "",
                        Author = node.SelectSingleNode("Author")?.Value ?? ""
                    });
                }

                //return list of books from inventory
                return results;
            }
        }
    }
}
