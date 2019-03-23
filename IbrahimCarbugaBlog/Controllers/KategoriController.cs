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
    public class KategoriController : Controller
    {
        [CustomAuthorize(isAdmin: true)]
        public ActionResult List()
        {
            return View(KategoriModel.GetList());
        }

        [CustomAuthorize(isAdmin: true)]
        public ActionResult Create()
        {
            return PartialView();
        }

        [CustomAuthorize(isAdmin: true)]
        [HttpPost]
        public ActionResult Create(KategoriModel km)
        {
            try
            {
                Kategori kategori = new Kategori();
                kategori.KategoriAdi = km.KategoriAdi;
                DbFactory.KategoriCrud.Insert(kategori);
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        [CustomAuthorize(isAdmin: true)]
        public ActionResult Edit(string id)
        {
            return PartialView(KategoriModel.GetList().FirstOrDefault(x=>x.KategoriId==id));
        }

        [CustomAuthorize(isAdmin: true)]
        [HttpPost]
        public ActionResult Edit(string id, KategoriModel km)
        {
            try
            {
                Kategori kategori = DbFactory.KategoriCrud.Find(id);                
                kategori.KategoriAdi = km.KategoriAdi;
                DbFactory.KategoriCrud.Update(id,kategori);
                return RedirectToAction("List");
            }
            catch(Exception ex)
            {
                return View(ex);
            }
        }

        [CustomAuthorize(isAdmin: true)]
        public ActionResult Delete(string id)
        {
            DbFactory.KategoriCrud.Delete(id);
            return RedirectToAction("List");
        }

       
    }
}
