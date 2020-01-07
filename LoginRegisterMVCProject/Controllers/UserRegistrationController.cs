﻿using Business;
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
            byte[] profilePictureByteArray = null;

            if (image != null)
            {
                profilePictureByteArray = new byte[image.ContentLength];
                image.InputStream.Read(profilePictureByteArray, 0, profilePictureByteArray.Length);
            }

            bool isRegistered = registrationManager.RegisterUser(appUser, profilePictureByteArray);

            if (isRegistered)
            {
                LoginUserDTO user = GetUserLoginCredentials(appUser.UserName, appUser.Password);
                return new UserLoginController().Login(user);
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
        //// GET: UserRegistration/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: UserRegistration/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: UserRegistration/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: UserRegistration/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: UserRegistration/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: UserRegistration/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: UserRegistration/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}