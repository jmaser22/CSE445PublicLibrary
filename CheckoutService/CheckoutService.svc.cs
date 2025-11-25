using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Hosting;
using System.Xml;

namespace CheckoutService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CheckoutService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CheckoutService.svc or CheckoutService.svc.cs at the Solution Explorer and start debugging.
    public class CheckoutService : ICheckoutService
    {
        public bool CheckoutBook(string title)
        {
            //Finds physical path of the file
            string path = HostingEnvironment.MapPath(@"~/App_Data/Books.xml");

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
        }

    }
}
