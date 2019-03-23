using IbrahimCarbugaBlog.Classes;
using IbrahimCarbugaBlog.Entity;
using IbrahimCarbugaBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IbrahimCarbugaBlog.Controllers
{
    public class YorumController : Controller
    {    
        [CustomAuthorize(isAdmin:true)]
        public ActionResult List()
        {
            return View(YorumModel.GetList());
        }
        [CustomAuthorize(isAdmin: true)]
        public ActionResult Details(string id)
        {
            return PartialView(YorumModel.GetList().FirstOrDefault(x=>x.YorumId==id));
        }

        [CustomAuthorize(isAdmin: true)]
        public ActionResult Delete(string id)
        {
            DbFactory.YorumCrud.Delete(id);
            return RedirectToAction("List");
        }

       
    }
}
