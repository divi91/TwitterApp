using System.Web.Mvc;
using TwitterReactMVC.BLL;

namespace TwitterReactMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View ();
        }
        [HttpGet]
        public string Get(string screenName)
        {
            TwitterDataBLL tBLL = new TwitterDataBLL();
            string tData = tBLL.GetTwitterData(screenName);
            return tData;
        }
    }
}
