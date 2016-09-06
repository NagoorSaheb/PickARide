using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using RolePro.Models.ViewModel;
using RolePro.Models.EntityManager;
using System.ComponentModel.DataAnnotations;


namespace RolePro.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(UserSignUpView USV)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                if (!UM.IsLoginNameExist(USV.LoginName))
                {
                    UM.AddUserAccount(USV);
                    FormsAuthentication.SetAuthCookie(USV.FirstName, false);
                    return RedirectToAction("Welcome", "Home");

                }
                else
                    ModelState.AddModelError("", "Login Name already taken.");
            }
            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(UserLoginView ULV, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                string password = UM.GetUserPassword(ULV.LoginName);

                if (string.IsNullOrEmpty(password))
                    ModelState.AddModelError("", "The user login or password provided is incorrect.");
                else
                {
                    if (ULV.Password.Equals(password))
                    {
                        FormsAuthentication.SetAuthCookie(ULV.LoginName, false);
                        return RedirectToAction("Welcome", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "The password provided is incorrect.");
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(ULV);
        }


        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        // GET: Account
        public ActionResult RequestRide()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RequestRide(UserRequestRideView USRV)
        {
            Console.WriteLine("Came from html page "+USRV.SYSUserId);

          

            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
              
                   UM.RequestRide(USRV);
                   return RedirectToAction("Welcome", "Home");

                }
                else
                    ModelState.AddModelError("", "Request Cant be processed at this time.");
            
            return View();
        }


        [HttpPost]
        public ActionResult SubmitRequest(string userID, string phone, string persons, string comments)
        {
                     
            UserRequestRideView USRV = new UserRequestRideView();
           
            USRV.AddPhoneNumber = phone;
            USRV.Comments = comments;
            USRV.NumberOfPersons = persons;
            USRV.loginName = userID;

            Console.WriteLine("Came from html page " + userID);
            Console.WriteLine("Number received from page " + phone);
            Console.WriteLine("comments from page " + userID);
            UserManager UM = new UserManager();
              
                   UM.RequestRide(USRV);

            return Json(new { success = true });
        }
    }
}