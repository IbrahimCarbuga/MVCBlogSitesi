using IbrahimCarbugaBlog.Classes;
using IbrahimCarbugaBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IbrahimCarbugaBlog.Controllers
{
    public class UserController : Controller
    {
        // GET: LoginRegister
        public ActionResult Index()
        {
            return View();
        }

        [CustomAuthorize(isAdmin: true)]
        public ActionResult List()
        {
            return View(UserModel.GetList());
        }

        [CustomAuthorize(isAdmin: true)]       
        public ActionResult Details(string id)
        {
            return PartialView(UserModel.GetList().FirstOrDefault(x=>x.UserId==id));
        }        

       
        [CustomAuthorize(isAdmin:true)]
        public ActionResult Delete(string id)
        {
            DbFactory.UserCrud.Delete(id);
            return RedirectToAction("List");
        }

       
    }
}
