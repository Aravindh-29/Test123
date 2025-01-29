using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleAspWithLoginPage.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            // Hardcoded credentials
            string validUsername = "admin";
            string validPassword = "123";

            if (username == validUsername && password == validPassword)
            {
                // Set session variable
                Session["User"] = username;

                // Redirect to Home Page
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Message = "Invalid credentials. Try again.";
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}