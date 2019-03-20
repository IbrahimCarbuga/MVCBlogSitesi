using OhmCrud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IbrahimCarbugaBlog.Entity
{
    public class Gonderi : DbObject
    {
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public Kategori Kategori { get; set; }
        public List<Yorum> Yorumlar { get; set; }
        public override string ToString()
        {
            return Icerik;
        }
    }
}