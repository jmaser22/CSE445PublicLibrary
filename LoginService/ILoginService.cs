using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LoginService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILoginService" in both code and config file together.
    [ServiceContract]
    public interface ILoginService
    {

        [OperationContract]
        [WebGet(UriTemplate = "RegisterNewSession?sessionId={sessionId}")]
        string RegisterNewSession(string sessionId);

        [OperationContract]
        [WebGet(UriTemplate = "VerifySessionId?sessionId={sessionId}")]

        string VerifySessionId(string sessionId);


        [OperationContract]
        [WebGet(UriTemplate = "GetEncryptedString?sessionId={sessionId}")]

        string GetEncryptedString(string sessionId);

        [OperationContract]
        [WebGet(UriTemplate = "StoreEncryptedString?sessionId={sessionId}&stringToStore={stringToStore}")]
        string StoreEncryptedString(string sessionId, string stringToStore);

        //Assignment6 add ons
        [OperationContract]
        [WebGet(UriTemplate = "LoginAuth?username={username}&HashedPassword={HashedPassword}")]
        string LoginAuth(string username, string HashedPassword);

        [OperationContract]
        [WebGet(UriTemplate = "RegisterNewUser?username={username}&HashedPassword={HashedPassword}&role={role}")]
        string RegisterNewUser(string userName, string HashedPassword, string role);
    }

}
