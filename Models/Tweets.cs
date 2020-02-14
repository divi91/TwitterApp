using System;
namespace TwitterReactMVC.Models
{
    public class Tweets
    {
        public string tweettext { get; set; }
        public string created { get; set; }
        public string retweets { get; set; }
        public string mediaType { get; set; }
        public string mediaUrl { get; set; }

        public Tweets(string tweet, string date, string rtweet, string mType, string mUrl)
        {
            tweettext = tweet;
            created = date;
            retweets = rtweet;
            mediaType = mType;
            mediaUrl = mUrl;
        }
    }
}
