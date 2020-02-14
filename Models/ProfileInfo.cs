using System;
namespace TwitterReactMVC.Models
{
    public class ProfileInfo
    {
        public string userName { get; set; }

        public string screenName { get; set; }

        public string profileImageUrl { get; set; }

        public string description { get; set; }

        public string followers { get; set; }

        public string following { get; set; }

        public ProfileInfo(string uName, string sName, string profileUrl, string desc, string follower, string followings)
        {
            userName = uName;
            screenName = sName;
            profileImageUrl = profileUrl;
            description = desc;
            followers = follower;
            following = followings;
        }
    }
}
