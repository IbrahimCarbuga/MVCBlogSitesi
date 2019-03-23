using IbrahimCarbugaBlog.Classes;
using IbrahimCarbugaBlog.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IbrahimCarbugaBlog.Models
{
    public class PostModel
    {
        public string ModelId { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public string Kategori { get; set; }
        public List<Yorum> Yorumlar { get; set; }
        public PostModel()
        {
            Yorumlar = new List<Yorum>();
        }
        public static List<PostModel> GetList()
        {
            List<PostModel> returnList = new List<PostModel>();
            foreach (Gonderi gonderi in DbFactory.GonderiCrud.Records)
            {
                PostModel pm = new PostModel();
                pm.ModelId = gonderi.ID;
                pm.Baslik = gonderi.Baslik;
                pm.Icerik = gonderi.Icerik;               
                pm.Kategori = gonderi.Kategori.KategoriAdi;
                pm.Yorumlar = gonderi.Yorumlar;
                returnList.Add(pm);
            }
            return returnList;
        }
    }
}