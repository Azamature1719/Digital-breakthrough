using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SolveITMail.Models;
using Newtonsoft.Json;

namespace SolveITMail.Controllers
{
    public class ClientController : Controller
    {
        private ISendDataReader Reader;
        private ISendDataWriter Writer;

        public ClientController(ISendDataReader reader, ISendDataWriter writer)
        {
            Reader = reader;
            Writer = writer;
        }

        /********************************************************************\
        МЕТОД.....: Cabinet
        ВИД.......: Личный кабинет
        \********************************************************************/
        public ActionResult Cabinet()
        {
            if (HttpContext.Session.GetString("user") == null)
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            CUser user = JsonConvert.DeserializeObject<CUser>(HttpContext.Session.GetString("user"));
            ViewBag.User = user;
            ViewBag.Sent = Reader.Read(user);
            return View();
        }

        /********************************************************************\
        МЕТОД.....: Cabinet
        ВИД.......: Личный кабинет
        ОПИСАНИЕ..: Добавляет новую посылку
        \********************************************************************/
        [HttpPost]
        public ActionResult Cabinet(string from, string to, string recipient, string address, string weight)
        {
            if (HttpContext.Session.GetString("user") == null)
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            CUser user = JsonConvert.DeserializeObject<CUser>(HttpContext.Session.GetString("user"));
            try
            {
                Writer.Write(user, new CSendData(from, to, from, recipient, address, double.Parse(weight)));
            } catch { }
            ViewBag.User = user;
            ViewBag.Sent = Reader.Read(user);
            return View();
        }
    }
}
