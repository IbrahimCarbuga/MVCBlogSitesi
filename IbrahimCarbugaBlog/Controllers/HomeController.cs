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
    public class HomeController : Controller
    {
        public ActionResult Index(string kategoriIsmi)
        {
            if (kategoriIsmi != null)
            {
                return View(PostModel.GetList().Where(x => x.Kategori == kategoriIsmi));
            }
            else
            {
                return View(PostModel.GetList());
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult TumPostlar(string kategoriAdı) //template List
        {
            if (kategoriAdı == null)
            {
                return View(PostModel.GetList());
            }
            else
            {
                return View(PostModel.GetList().Where(x => x.Kategori == kategoriAdı));
            }

        }

        public ActionResult PostOku(string id) // template Empty
        {
            Session["currentPostId"] = id; // Şu anda hangi post görüntüleniyor bilmek için
            return View(PostModel.GetList().FirstOrDefault(x => x.ModelId == id));
        }

        [HttpPost]
        public ActionResult YorumYap(string yorumIcerik)
        {
           
                Yorum yorum = new Yorum();
                yorum.YorumIcerigi = yorumIcerik;
                string userid = Session["userId"].ToString();
                User currentuser = DbFactory.UserCrud.Find(userid);// Şu anda kayıt yapan kullanıcı olacak
                yorum.User = currentuser;
                var currentPost = DbFactory.GonderiCrud.Find(Session["currentPostId"].ToString());
                currentPost.Yorumlar.Add(yorum);
                DbFactory.GonderiCrud.Update(currentPost.ID, currentPost);
                return RedirectToAction("PostOku", new { id = Session["currentPostId"].ToString() });// PostOkuya geri dön id parametresini postId'ye Eşitle
          
 
        }
    }
}