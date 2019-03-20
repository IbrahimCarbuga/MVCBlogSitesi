using IbrahimCarbugaBlog.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IbrahimCarbugaBlog.Classes
{
    public class CustomAuthorizeAttribute:AuthorizeAttribute
    {
        private bool _isAdmin { get; set; }
        public CustomAuthorizeAttribute(bool isAdmin)
        {
            _isAdmin = isAdmin;
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var cookie = filterContext.HttpContext.Request.Cookies.Get("userId");
            if (cookie == null)
            {
                filterContext.Result = new RedirectResult("/Error/UnAuthorized401");
            }
            else
            {
                var decryptedId = OhmCryptor.OhmCryptor.Decrypt(cookie.Value, UserFactory.SuperSecretKey);
                //Get UserInfoFromDatabase
                User currentUser = DbFactory.UserCrud.Find(decryptedId);

                if (currentUser.UserType == UserType.Normal && _isAdmin == true)//Normal bir kullanıcı admin tarafına girmek istemiş
                {
                    filterContext.Result = new RedirectResult("/Error/Forbidden403");

                }
                else if (currentUser.UserType == UserType.Admin && _isAdmin == false)//Admin bir kullanıcı Normal tarafına girmek istemiş
                {
                    filterContext.Result = new RedirectResult("/Error/Forbidden403");

                }
            }
        }
    }
}