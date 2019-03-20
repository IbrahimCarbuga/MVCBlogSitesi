using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IbrahimCarbugaBlog.Classes
{
    public static class SelectListFactory
    {
        public static SelectList KategoriSelectList = new SelectList(DbFactory.KategoriCrud.Records);
    }
}