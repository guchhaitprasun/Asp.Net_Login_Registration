using Business;
using Shared.ApplicationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginRegisterMVCProject.Controllers
{
    public class UserRegistrationController : Controller
    {
        // GET: UserRegistration
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(AppUserDTO appUser, HttpPostedFileBase image)
        {
            RegistrationManager registrationManager = new RegistrationManager();

            //Getting base 64 sring fro image
            byte[] profilePictureByteArray = CreateBase64String(image);

            if(profilePictureByteArray.Length > 0)
            {
                bool isRegistered = registrationManager.RegisterUser(appUser, profilePictureByteArray);
                if (isRegistered)
                {
                    LoginUserDTO user = GetUserLoginCredentials(appUser.UserName, appUser.Password);
                    return RedirectToAction("Index", "Playground");
                }
            }
            return View("Error");

        }

        public LoginUserDTO GetUserLoginCredentials(string userName, string password)
        {
            LoginUserDTO user = new LoginUserDTO();
            if (userName != null && password != null)
            {
                user.UserName = userName;
                user.Password = password;
            }

            return user;
        }

        private byte[] CreateBase64String(HttpPostedFileBase data)
        {
            byte[] imageDataByteArray = new byte[0];
            if (data != null && data.ContentType.Contains("image") && data.ContentLength < 200000)
            {
                imageDataByteArray = new byte[data.ContentLength];
                data.InputStream.Read(imageDataByteArray, 0, imageDataByteArray.Length);
            }
            return imageDataByteArray;
        }
    }
}
