using System;
namespace TwitterReactMVC.Models
{
    public class TwitterData
    {
        public ProfileInfo profileInfo { get; set; }
        public Tweets[] Tweets { get; set; }

        public TwitterData(ProfileInfo pInfo, Tweets[] tdata)
        {
            profileInfo = pInfo;
            Tweets = tdata;
        }
    }
}
