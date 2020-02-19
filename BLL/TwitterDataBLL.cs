using System;
using Newtonsoft.Json.Linq;
using TwitterReactMVC.DAL;
using TwitterReactMVC.Models;
using System.Web.Script.Serialization;

namespace TwitterReactMVC.BLL
{
    public class TwitterDataBLL
    {
        public string GetTwitterData(string screenName)
        {
            TweetDAL tDAL = new TweetDAL();
            string data = tDAL.GetData(screenName);
            var jsonObject = JArray.Parse(data);

            if (jsonObject.HasValues)
            {
                string temp = (string)jsonObject[0]["user"]["profile_image_url_https"];

                ProfileInfo tProfileInfo = new ProfileInfo((string)jsonObject[0]["user"]["name"], (string)jsonObject[0]["user"]["screen_name"],
                      temp.Substring(0, (temp.Length - ((temp.Substring(temp.IndexOf("_normal."))).Length))) + temp.Substring(temp.IndexOf("_normal.") + 7),
                      (string)jsonObject[0]["user"]["description"], (string)jsonObject[0]["user"]["followers_count"], (string)jsonObject[0]["user"]["friends_count"]);

                Tweets[] tData = new Tweets[10];
                int count = 0;

                foreach (var item in jsonObject)
                {
                    string Const_TwitterDateTemplate = "ddd MMM dd HH:mm:ss +ffff yyyy";
                    DateTime createdAt = DateTime.ParseExact((string)item["created_at"], Const_TwitterDateTemplate, new System.Globalization.CultureInfo("en-US"));
                    string mediaUrl = "", mediaType = "", retweet = "";

                    if (item.SelectToken("retweeted_status") != null)
                    {
                        retweet = (string)item["retweeted_status"]["full_text"];
                    }
                    if (item["entities"].HasValues)
                    {
                        if (item.SelectToken("extended_entities") != null)
                        {
                            if (item["extended_entities"].SelectToken("media") != null)
                            {
                                if ((string)item["extended_entities"]["media"][0]["type"] == "photo")
                                {
                                    mediaType = "photo";
                                    mediaUrl = (string)item["extended_entities"]["media"][0]["media_url_https"];
                                }
                                else if ((string)item["extended_entities"]["media"][0]["type"] == "video")
                                {
                                    mediaType = "video";
                                    string[] url = new string[4];
                                    int rate = 0, j = 0;
                                    JArray tempArr = (JArray)item["extended_entities"]["media"][0]["video_info"]["variants"];
                                    for (int i = 0; i < tempArr.Count; i++)
                                    {
                                        if ((string)item["extended_entities"]["media"][0]["video_info"]["variants"][i]["content_type"] == "video/mp4")
                                        {
                                            url[i] = (string)item["extended_entities"]["media"][0]["video_info"]["variants"][i]["url"];
                                            if (rate == 0)
                                            {
                                                rate = (int)item["extended_entities"]["media"][0]["video_info"]["variants"][i]["bitrate"];
                                                j = i;
                                            }
                                            else
                                            {
                                                if (rate > (int)item["extended_entities"]["media"][0]["video_info"]["variants"][i]["bitrate"])
                                                {
                                                    rate = (int)item["extended_entities"]["media"][0]["video_info"]["variants"][i]["bitrate"];
                                                    j = i;
                                                }
                                            }
                                        }
                                    }
                                    mediaUrl = (string)item["extended_entities"]["media"][0]["video_info"]["variants"][j]["url"];
                                }
                            }
                        }
                    }
                    if (retweet != "")
                    {
                        tData[count] = new Tweets(retweet, createdAt.ToString(), (string)item["retweet_count"], mediaType, mediaUrl);
                    }
                    else
                    {
                        tData[count] = new Tweets((string)item["full_text"], createdAt.ToString(), (string)item["retweet_count"], mediaType, mediaUrl);
                    }

                    count++;
                }

                TwitterData tProfile = new TwitterData(tProfileInfo, tData);
                var tProfileJson = new JavaScriptSerializer().Serialize(tProfile);
                return tProfileJson;
            }
            else
            {
                return "{}";
            }
        }
    }
}
