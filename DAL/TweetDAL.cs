using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;

namespace TwitterReactMVC.DAL
{
    public class TweetDAL
    {
        private static string GetAuthToken()
        {
            string credentials = Convert.ToBase64String(new UTF8Encoding()
                              .GetBytes(ConfigurationManager.AppSettings["tKey"] + ":" + ConfigurationManager.AppSettings["tSecret"])).ToString();

            if (string.IsNullOrEmpty(credentials))
            {
                throw new HttpListenerException(400, "Twitter key is invalid");
            }
            string access_token = "";

            var post = (HttpWebRequest)WebRequest.Create("https://api.twitter.com/oauth2/token") as HttpWebRequest;

            post.Method = "POST";
            post.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
            post.Headers[HttpRequestHeader.Authorization] = "Basic " + credentials;
            var reqbody = Encoding.UTF8.GetBytes("grant_type=client_credentials");
            post.ContentLength = reqbody.Length;
            using (var req = post.GetRequestStream())
            {
                req.Write(reqbody, 0, reqbody.Length);
            }
            try
            {
                string respbody = null;
                using (var resp = post.GetResponse().GetResponseStream())
                {
                    var respR = new StreamReader(resp);
                    respbody = respR.ReadToEnd();
                    access_token = respbody.Substring(respbody.IndexOf("\"access_token\":\"") + "\"access_token\":\"".Length, respbody.IndexOf("\"}") - respbody.IndexOf("\"access_token\":\"") - "\"access_token\":\"".Length);
                    return access_token;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetData(string screenName)
        {
            string authToken = GetAuthToken();

            var gettimeline = WebRequest.Create("https://api.twitter.com/1.1/statuses/user_timeline.json?count=10&tweet_mode=extended&screen_name=" + screenName) as HttpWebRequest;
            gettimeline.Method = "GET";
            gettimeline.Headers[HttpRequestHeader.Authorization] = "Bearer " + authToken;

            try
            {
                string respbody = null;
                using (var resp = gettimeline.GetResponse().GetResponseStream())
                {
                    var respR = new StreamReader(resp);
                    respbody = respR.ReadToEnd();
                }
                return respbody;
            }
            catch (Exception ex)
            {
                return "[]";
                throw ex;
            }
        }
    }

}
