using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SolveITMail.Models;
using Newtonsoft.Json;

namespace SolveITMail.Controllers
{
    public class HomeController : Controller
    {
        private IAuthenticator Authenticator;
        private IAdvertisingFinder Advertising;
        public HomeController(IAuthenticator auth, IAdvertisingFinder advertising)
        {
            Authenticator = auth;
            Advertising = advertising;
        }

        [HttpPost]
        public IActionResult Login(CAuthorizationData data)
        {
            CUser user = Authenticator.Find(data);
            if (user != null)
            {
                HttpContext.Session.SetString("user", JsonConvert.SerializeObject(data));
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            return RedirectToRoute(new { controller = "Home", action = "Login" });
        }

        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("user") != null)
                RedirectToRoute(new { controller = "Home", action = "Index" });
            return View();
        }

        public ActionResult Index()
        {
            List<CAdvertising> check = Advertising.Find(EClasterID.Young);
            string tmp = HttpContext.Session.GetString("user");
            if (tmp != null)
            {
                CUser user = JsonConvert.DeserializeObject<CUser>(tmp);
                ViewBag.User = user;
                ViewBag.Advertising = Advertising.Find(user.Claster);
            }
            return View();
        }

        public ActionResult Exit()
        {
            HttpContext.Session.Clear();
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }
    }
}
