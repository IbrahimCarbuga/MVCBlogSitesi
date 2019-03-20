using OhmCrud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IbrahimCarbugaBlog.Entity
{
    public class Kategori : DbObject
    {
        public string KategoriAdi { get; set; }
        public override string ToString()
        {
            return KategoriAdi; 
        }
    }
}