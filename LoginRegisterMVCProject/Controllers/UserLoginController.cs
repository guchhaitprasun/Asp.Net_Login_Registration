using Business.Managers;
using Shared.ApplicationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginRegisterMVCProject.Controllers
{
    public class UserLoginController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginUserDTO user)
        {
            LoginManager loginManager = new LoginManager();
            LoginUserDTO authenticatedUser = new LoginUserDTO();
            authenticatedUser = loginManager.AuthenticateUser(user);

            if (authenticatedUser.UserName != null && authenticatedUser.userId > 0)
            {

                //store data in cache
                return RedirectToAction("Index", "Playground");
            }
            else {
                return View("Error");
            }
        }
    }
}