using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SolveITMail.Models;
using Newtonsoft.Json;

namespace SolveITMail.Controllers
{
    public class HomeController : Controller
    {
        private IAuthenticator     Authenticator; // Аутентификатор пользователей
        private IAdvertisingFinder Advertising;   // Генератор рекламы

        public HomeController(IAuthenticator auth, IAdvertisingFinder advertising)
        {
            Authenticator = auth;
            Advertising = advertising;
        }

        /********************************************************************\
        МЕТОД.....: Login
        ВИД.......: Авторизация
        ОПИСАНИЕ..: Проводит аутентификацию пользователя по введённым логину и
                    паролю.
        ПАРАМЕТРЫ.: CAuthorizationData data - данные для входа
        \********************************************************************/
        [HttpPost]
        public IActionResult Login(CAuthorizationData data)
        {
            CUser user = Authenticator.Find(data);
            if (user != null)
            {
                HttpContext.Session.SetString("user", JsonConvert.SerializeObject(user));
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            return RedirectToRoute(new { controller = "Home", action = "Login" });
        }

        /********************************************************************\
        МЕТОД.....: Login
        ВИД.......: Страница авторизации
        \********************************************************************/
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("user") != null)
                RedirectToRoute(new { controller = "Home", action = "Index" });
            return View();
        }

        /********************************************************************\
        МЕТОД.....: Index
        ВИД.......: Главная страница
        \********************************************************************/
        public ActionResult Index()
        {
            string tmp = HttpContext.Session.GetString("user");
            if (tmp != null)
            {
                CUser user = JsonConvert.DeserializeObject<CUser>(tmp);
                ViewBag.User = user;
                //ViewBag.Advertising = Advertising.Find(user.Claster);
            }
            return View();
        }

        /********************************************************************\
        МЕТОД.....: Exit
        ВИД.......: Главная страница
        ОПИСАНИЕ..: Очищает сессию и возвращает пользователя на главную
                    страницу
        \********************************************************************/
        public ActionResult Exit()
        {
            HttpContext.Session.Clear();
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }
    }
}
