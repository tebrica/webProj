using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                Database.users.Add("asd", new User("asd", "asd"));
                Database.users.Add("qwe", new User("qwe", "asd"));
                Database.users.Add("zxc", new User("zxc", "asd"));
                Database.users.Add("123", new User("123", "asd"));
            }
            catch { }

            return View();
        }
        [HttpPost]
        public ActionResult Login()
        {
            string username = Request["username"] == null ? string.Empty : Request["username"];
            string password = Request["password"] == null ? string.Empty : Request["password"];

            var user = new User(username, password);
            try
            {
                if (Database.users[username].password.Equals(password))
                {
                    Session["user"] = user;
                    ViewBag.message = string.Empty;
                    return View("Index");
                }
                ViewBag.message = "wrong pass";
            }
            catch
            {
                ViewBag.message = "no user";
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult GetTable()
        {
            return View("Login", Database.users);
        }
    }
}