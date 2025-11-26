using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml;

namespace LoginService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LoginService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LoginService.svc or LoginService.svc.cs at the Solution Explorer and start debugging.
    public class LoginService : ILoginService
    {
        string sessionDataFp = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Session_Data.xml");

        string userDataFp = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/User_data.xml");


        public string RegisterNewSession(string sessionId)
        {

            //Register as a new session in the xml file
            XmlDocument sessionData = new XmlDocument();
            try
            {
                sessionData.Load(sessionDataFp);
            }
            catch
            {
                XmlDeclaration decl = sessionData.CreateXmlDeclaration("1.0", "UTF-8", null);
                sessionData.AppendChild(decl);

                XmlElement title = sessionData.CreateElement("Sessions");
                sessionData.AppendChild(title);
            }
            XmlNode root = sessionData.DocumentElement;


            XmlNode titleNode = sessionData.CreateElement("SessionEntry");

            //Create necessary elements for storing a new session of data
            XmlElement sessionIdElmt = sessionData.CreateElement("SessionId");
            sessionIdElmt.InnerText = sessionId;
            titleNode.AppendChild(sessionIdElmt);

            XmlElement eString = sessionData.CreateElement("EncryptedString");
            eString.InnerText = "";
            titleNode.AppendChild(eString);

            root.AppendChild(titleNode);

            sessionData.Save(sessionDataFp);


            //Return a succesful message
            return "Success";
        }

        public string VerifySessionId(string sessionId)
        {


            //Check xml file to verify sessionId exists
            XmlDocument session_data = new XmlDocument();
            try
            {
                session_data.Load(sessionDataFp);
                XmlNodeList entries = session_data.SelectNodes("/Sessions/SessionEntry"); //load all entries of session data collected

                foreach (XmlNode entry in entries) //Parse entries 
                {
                    if (entry["SessionId"].InnerText == sessionId)
                    {
                        return sessionId;
                    }
                }
            }
            catch (Exception ex)
            {
                return "Invalid sessionId";
            }
            return "Invalid SessionId, clear cookies and start over";
        }

        //Returns the encrypted string or just NULL
        public string GetEncryptedString(string sessionId)
        {

            //Find the sessionId entry in xml file and get the most recent string
            //If empty return "NULL" else return string
            XmlDocument session_data = new XmlDocument();
            try
            {
                session_data.Load(sessionDataFp);
                XmlNodeList entries = session_data.SelectNodes("/Sessions/SessionEntry"); //load all entries of session data collected

                foreach (XmlNode entry in entries) //Parse entries 
                {
                    if (entry["SessionId"].InnerText == sessionId)
                    {
                        return entry["EncryptedString"].InnerText;
                    }
                }
            }
            catch (Exception ex)
            {
                return "NULL";
            }



            return "NULL";
        }

        //Find the right session then update it's most recent string entered by the user
        public string StoreEncryptedString(string sessionId, string stringToStore)
        {

            XmlDocument session_data = new XmlDocument();
            try
            {
                session_data.Load(sessionDataFp);
                XmlNodeList entries = session_data.SelectNodes("/Sessions/SessionEntry"); //load all entries of session data collected

                foreach (XmlNode entry in entries) //Parse entries 
                {
                    if (entry["SessionId"].InnerText == sessionId)
                    {
                        entry["EncryptedString"].InnerText = stringToStore;

                        session_data.Save(sessionDataFp);
                        return "Success!";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Exception, string not saved";
            }
            return "Error saving string, invalid sessionId";

        }




        //Assignment 6 services added on for verifying user login and their role, then registration as well

        //Search through the XML file of user data to verify they exist in the user database, if so return staff or member, if not return "Invalid credentials"
        public string LoginAuth(string username, string HashedPassword)
        {
            XmlDocument user_data = new XmlDocument();
            try
            {
                XmlNodeList entries;
                try
                {
                    user_data.Load(userDataFp);
                    entries = user_data.SelectNodes("/Users/User"); //load all entries of user data collected
                } catch (Exception ex)
                {
                    return "No user exists yet";
                }

                foreach (XmlNode entry in entries) //Parse entries 
                {
                    if (entry["Username"].InnerText == username)
                    {

                        string xmlPw = entry["EncryptedPassword"].InnerText;
                        if (HashedPassword == entry["EncryptedPassword"].InnerText) return entry["Role"].InnerText;
                        else return "Invalid Password";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Encountered error logging in" + ex.Message;
            }

            return "Username not found";

        }

        //needs to add a new user onto the 
        public string RegisterNewUser(string userName, string HashedPassword, string role)
        {
            //open a new or existing xml doc, add a new user onto it with password and username and their role
            XmlDocument userData = new XmlDocument();
            try
            {
                userData.Load(userDataFp);

                //check for duplicate user names, to prevent registering under the same username
                XmlNodeList entries = userData.SelectNodes("/Users/User"); //load all entries of user data collected
                foreach (XmlNode entry in entries) //Parse entries 
                {
                    if (entry["Username"].InnerText == userName)
                    {
                        return "Username already exists, Try Again";
                    }
                }
            }
            catch
            {
                XmlDeclaration decl = userData.CreateXmlDeclaration("1.0", "UTF-8", null);
                userData.AppendChild(decl);

                XmlElement title = userData.CreateElement("Users");
                userData.AppendChild(title);
            }
            XmlNode root = userData.DocumentElement;


            XmlNode NewUser = userData.CreateElement("User");

            //Create username element for new user xml entry
            XmlElement usernameElmt = userData.CreateElement("Username");
            usernameElmt.InnerText = userName;
            NewUser.AppendChild(usernameElmt);



            //attach the password onto it
            XmlElement passwordElmt = userData.CreateElement("EncryptedPassword");

            passwordElmt.InnerText = HashedPassword;
            NewUser.AppendChild(passwordElmt);


            //Attach role
            XmlElement roleElmnt = userData.CreateElement("Role");
            roleElmnt.InnerText = role;
            NewUser.AppendChild(roleElmnt);


            //Attach new user to the xml file
            root.AppendChild(NewUser);


            userData.Save(userDataFp);


            //Return a succesful message
            return "Success";
        }
    }
}
