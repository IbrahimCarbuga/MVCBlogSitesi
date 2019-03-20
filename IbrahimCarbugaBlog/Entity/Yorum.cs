using OhmCrud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IbrahimCarbugaBlog.Entity
{
    public class Yorum : DbObject
    {
        public User User { get; set; }
        public string YorumIcerigi { get; set; }
        public bool GecerliMi { get; set; }
        public override string ToString()
        {
            return YorumIcerigi;
        }
    }
}