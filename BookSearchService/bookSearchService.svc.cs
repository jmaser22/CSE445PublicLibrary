using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using static System.Net.WebRequestMethods;

namespace BookSearchService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "bookSearchService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select bookSearchService.svc or bookSearchService.svc.cs at the Solution Explorer and start debugging.
    public class bookSearchService : IbookSearchService
    {

        //need to figure out the security block to bypass 403 forbidden code. using local host for now
        private const string XmlUrl = "http://webstrar20.fulton.asu.edu/page10/Inventory.xml"; // your file URL

        //search for keyword in the inventory.xml file
        public List<XmlSearch.XmlSearch.Book> SearchBook(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return new List<XmlSearch.XmlSearch.Book>();

            //call XMLSearch from dll class
            List<XmlSearch.XmlSearch.Book> content = XmlSearch.XmlSearch.search(XmlUrl, keyword);


            return content;
        }
    }
}
