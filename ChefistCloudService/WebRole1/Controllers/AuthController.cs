using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebRole1.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth/Login
       
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

    }
}