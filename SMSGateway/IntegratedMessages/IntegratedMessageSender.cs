using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;

namespace IntegratedMessages
{
    public class IntegratedMessageSender
    {
        #region Private
        private const string URL = "http://smsclient-trans.packwebhosting.com";
        private const string TEMPLT_1 = "Dear User, Guest House booked successfully XXXXXX.";
        private const string TEMPLT_2 = "Dear User, Your are allotted Quarter XXXXX.";
        private const string TEMPLT_3 = "Dear User, Below are your login details. XXXXX";
        private const string API_KEY = "Abbc9c3910404e5e50ddb835d877fb281";
        private const string SENDER_ID = "EMASAG";

        private string ConstructURL(string template,string value,string mobileNumber)
        {
            string templateType = string.Empty;
            switch (template)
            {
                case "GUEST_HOUSE_BOOKING":
                    templateType = TEMPLT_1.Replace("XXXXXX",value);
                    break;
                case "NEW_USER":
                    templateType = TEMPLT_3.Replace("XXXXX", value);
                    break;
                case "QUARTER_ALLOTTED":
                    templateType = TEMPLT_2.Replace("XXXXX",value);
                    break;
                default:
                    throw new ArgumentNullException("template");
            }
            string url = URL + "/api/v4/index.php?method=sms&api_key=" + API_KEY + "&to=" + mobileNumber + "&sender=" + SENDER_ID;
            url += "&message=" + templateType + "&format=json&custom=1,2&flash=0";

            return url;
        }

        #endregion

        #region Public

        public string SendMessage(string type,string value,string mobileNumber)
        {
            string url = ConstructURL(type, value, mobileNumber);
            var client = new RestClient(url);

            var request = new RestRequest(Method.GET);

            // execute the request
            var response = client.Execute(request);
            return response.Content;
        }

        #endregion
    }
}
