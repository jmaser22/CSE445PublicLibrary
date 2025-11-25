using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BookSearchService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IbookSearchService" in both code and config file together.
    [ServiceContract]
    public interface IbookSearchService
    {
        [OperationContract]
        [WebGet(UriTemplate = "SearchBook?keyword={keyword}", ResponseFormat = WebMessageFormat.Json)]
        List<XmlSearch.XmlSearch.Book> SearchBook(string keyword);
    }
}
