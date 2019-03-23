using IbrahimCarbugaBlog.Classes;
using IbrahimCarbugaBlog.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IbrahimCarbugaBlog.Models
{
    public class YorumModel
    {
        public string YorumId { get; set; }
        public string KullaniciAdi { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string YorumIcerigi { get; set; }        
        public static List<YorumModel> GetList()
        {
            List<YorumModel> returnList = new List<YorumModel>();
            foreach (Yorum yorum in DbFactory.YorumCrud.Records)
            {
                YorumModel ym = new YorumModel();                
                ym.YorumId = yorum.ID;
                ym.KullaniciAdi = yorum.User.KullaniciAdi;
                ym.DogumTarihi = yorum.User.DogumTarihi;
                ym.YorumIcerigi = yorum.YorumIcerigi;
                returnList.Add(ym);
            }
            return returnList;
        }
    }
}