using IbrahimCarbugaBlog.Classes;
using IbrahimCarbugaBlog.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IbrahimCarbugaBlog.Models
{
    public class KategoriModel
    {
        public string KategoriId { get; set; }
        public string KategoriAdi { get; set; }
        public static List<KategoriModel> GetList()
        {
            List<KategoriModel> returnList = new List<KategoriModel>();
            foreach (Kategori kategori in DbFactory.KategoriCrud.Records)
            {
                KategoriModel km = new KategoriModel();
                km.KategoriId = kategori.ID;
                km.KategoriAdi = kategori.KategoriAdi;
                returnList.Add(km);
            }
            return returnList;
        }
    }
}