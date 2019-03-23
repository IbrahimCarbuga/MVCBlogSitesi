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
    public class PostController : Controller
    {

        [CustomAuthorize(isAdmin: true)]
        public ActionResult List()
        {
            return View(PostModel.GetList());
        }

        [CustomAuthorize(isAdmin: true)]
        public ActionResult Details(string id)
        {
            return PartialView(PostModel.GetList().FirstOrDefault(x=>x.ModelId==id));
        }

       
        [CustomAuthorize(isAdmin:true)]
        public ActionResult Create()
        {
            return PartialView();
        }

        
        [CustomAuthorize(isAdmin: true)]
        [HttpPost]
        public ActionResult Create(PostModel postModel)
        {
            try
            {
                Gonderi SuankiGonderi = new Gonderi();
                SuankiGonderi.Baslik = postModel.Baslik;
                SuankiGonderi.Icerik = postModel.Icerik;
                var kategori = DbFactory.KategoriCrud.Records.FirstOrDefault(x => x.KategoriAdi == postModel.Kategori);
                SuankiGonderi.Kategori = kategori;
                DbFactory.GonderiCrud.Insert(SuankiGonderi);
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
            return PartialView(PostModel.GetList().FirstOrDefault(x=>x.ModelId==id));
        }

        
        [CustomAuthorize(isAdmin: true)]
        [HttpPost]
        public ActionResult Edit(string id, PostModel postModel)
        {
            try
            {
                Gonderi SuankiGonderi = DbFactory.GonderiCrud.Find(id);
                SuankiGonderi.Baslik = postModel.Baslik;
                SuankiGonderi.Icerik = postModel.Icerik;
                var kategori = DbFactory.KategoriCrud.Records.FirstOrDefault(x => x.KategoriAdi == postModel.Kategori);
                SuankiGonderi.Kategori = kategori;
                DbFactory.GonderiCrud.Update(id,SuankiGonderi);

                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

       
        [CustomAuthorize(isAdmin: true)]
        public ActionResult Delete(string id)
        {
            DbFactory.GonderiCrud.Delete(id);
            return RedirectToAction("List");
        }
        
    }
}
