using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.Web.Hosting;
using System.Web;
using System.Diagnostics;

namespace CheckoutService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class CheckoutService : ICheckoutService
    {
        /*
        public bool CheckoutBook(string bookTitle)
        {
            //Lock ApplicationState object
            HttpContext.Current.Application.Lock(); 

            //Attempts to access cached books and checkout book
            try
            {
                //Load cached books
                XmlDocument books = (XmlDocument)HttpContext.Current.Application["Books"];

                //Debugging:
                if (HttpContext.Current.Application["Books"] == null)
                {
                    return true;
                }

                //Debugging direct instantiation of service
                if (books != null)
                {
                    Debug.WriteLine("This is what's in books xmldocument: ");
                    Debug.WriteLine(books.OuterXml);
                }

                //Find the book with the corresponding title
                XmlNode bookNode = books.SelectSingleNode($"/Library/Book[Title='{bookTitle}']");

                //No book with this title found in library
                if ( bookNode == null )
                {
                    return false;
                }

                //If book is in library, obtain book availability and borrow
                XmlNode availableNode = bookNode.SelectSingleNode("Available");
                XmlNode borrowerNode = bookNode.SelectSingleNode("Borrower");

                if (availableNode.InnerText == "false") //Check if book is available
                {
                    //If not available return false
                    return false;
                }
                else 
                {
                    //If available, checkout book
                    availableNode.InnerText = "false";
                    borrowerNode.InnerText = "TA";


                }

                //Saves updated books file to Application state
                HttpContext.Current.Application["Books"] = books;

                //Saves changes in cached books to xml file
                string path = HttpContext.Current.Server.MapPath("~/App_Data/Books.xml");
                books.Save(path);

                return true;

            }

            finally
            {
                //Unlock Application state object so cached books are accessible 
                HttpContext.Current.Application.UnLock();
            }

            
        }*/


        public bool CheckoutBook(string title)
        {
            //Finds physical path of the file
            //string path = HostingEnvironment.MapPath(@"~/App_Data/Books.xml");
            string path = "http://webstrar20.fulton.asu.edu/page10/Inventory.xml";

            //Loads in xml file storing all books in library
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            // Get all books

            XmlNodeList books = doc.GetElementsByTagName("Book");

            //Iterates through each of the books to find the desired book to checkout
            foreach (XmlNode book in books)
            {
                //Gets the title, availability, and borrower of the book
                XmlNode titleNode = book["Title"];
                XmlNode availableNode = book["Available"];
                XmlNode borrowerNode = book["Borrower"];

                //Testing
                string booktitle = titleNode.InnerText;
                string bookAvailability = availableNode.InnerText;
                //////////////


                //Checks that title and availability elements are not empty so it can check if it's the right book and if its available
                if (titleNode != null && availableNode != null)
                {
                    //Checks if the title corresponds with the desired book and if its available
                    if (titleNode.InnerText == title)
                    {
                        if (availableNode.InnerText == "true")
                        {
                            //Change availability to false
                            availableNode.InnerText = "false";

                            //Save borrower's name to borrower element
                            borrowerNode.InnerText = "TA";

                            //Save changes back to the books xml file
                            doc.Save(path);

                            // Returns true if checkout function is successful
                            return true;
                        }

                    }

                }
            }

            // Returns false if checkout function not successful
            return false;
        }/**/

        /*public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }*/
    }
}
