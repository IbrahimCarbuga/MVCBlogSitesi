using IbrahimCarbugaBlog.Classes;
using IbrahimCarbugaBlog.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IbrahimCarbugaBlog.Controllers
{
    public class LoginRegisterController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user, string rememberMe)
        {
            var userEntity = DbFactory.UserCrud.Records.FirstOrDefault(x => x.KullaniciAdi == user.KullaniciAdi && x.Sifre == user.Sifre);
            if (userEntity != null) //Kullanıcı var demektir
            {
                var encryptedId = OhmCryptor.OhmCryptor.Encrypt(userEntity.ID,UserFactory.SuperSecretKey);
                HttpCookie cookie = new HttpCookie("userId", encryptedId);
                if (rememberMe == null)
                {
                    cookie.Expires = DateTime.Now.AddHours(1);
                }
                else
                {
                    cookie.Expires = DateTime.Now.AddDays(30);
                }
                Response.Cookies.Add(cookie);
                return RedirectToAction("Index", "Home", null);
            }
            else //Kullanıcı bulunamadıysa
            {
                TempData["errorMessage"] = "Kullanıcı adı veya şifre hatalı";
                return View();
            }

        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            DbFactory.UserCrud.Insert(user);
            return RedirectToAction("Login");
        }
        public PartialViewResult UserInfo()
        {
            var cookie = Request.Cookies.Get("userId");
            if (cookie != null) //Kullanıcı Giriş Yapmışsa
            {
                User currentUser = UserFactory.GetCurrentUser(cookie.Value);
                //Kullanıcıyı bul
                return PartialView(currentUser); //View'a gönder
            }
            else //Kullanıcı giriş yapmamış ise
            {
                return PartialView(null); //Boşluk gönder 
            }
        }
        public ActionResult Logout()
        {
            var cookie = Request.Cookies.Get("userId");
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);
            return RedirectToAction("Login");
        }

    }
}