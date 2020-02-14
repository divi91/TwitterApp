using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitterReactMVC.BLL;
using TwitterReactMVC.Models;

namespace TwitterReactMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View ();
        }
        [HttpGet]
        public TwitterData Get()
        {
            string screenName = Request.QueryString.ToString();
            TwitterDataBLL tBLL = new TwitterDataBLL();
            TwitterData tData = tBLL.GetTwitterData(screenName);
            return tData;
        }
    }
}
