using OhmCrud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IbrahimCarbugaBlog.Entity
{
    public class User:DbObject
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string Email { get; set; }
        public DateTime DogumTarihi { get; set; }
        public UserType UserType { get; set; }
        

    }
}