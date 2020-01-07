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
            return View();
        }
    }
}