using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRole1.Services;

namespace WebRole1.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {


            
            return View();
        }

        [HttpGet]
        public new ActionResult Profile()
        {
            string userid = this.User?.Identity.GetUserId();

            if (String.IsNullOrEmpty(userid))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.UserEmail = User.Identity.GetUserName();
                ViewBag.MyRecipes = DBServices.GetUserRecipes(User.Identity.GetUserId());
                return View();
            }

            
        }

        public ActionResult Recipes()
        {
            return View();
        }
    }
}