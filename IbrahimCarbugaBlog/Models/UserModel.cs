using IbrahimCarbugaBlog.Classes;
using IbrahimCarbugaBlog.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IbrahimCarbugaBlog.Models
{
    public class UserModel
    {
        public string UserId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string Email { get; set; }
        public int KullaniciTipi { get; set; }
        public DateTime DogumTarihi { get; set; }
        public static List<UserModel> GetList()
        {
            List<UserModel> returnList = new List<UserModel>();
            foreach (User user in DbFactory.UserCrud.Records)
            {
                UserModel um = new UserModel();
                um.UserId = user.ID;
                um.Ad = user.Ad;
                um.Soyad = user.Soyad;
                um.KullaniciAdi = user.KullaniciAdi;
                um.Sifre = user.Sifre;
                um.Email = user.Email;
                um.DogumTarihi = user.DogumTarihi;
                um.KullaniciTipi = Convert.ToInt32(UserType.Normal);
                returnList.Add(um);
            }
            return returnList;
        }
    }
}