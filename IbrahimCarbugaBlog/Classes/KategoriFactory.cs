using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IbrahimCarbugaBlog.Classes
{
    public static class KategoriFactory
    {
        public static List<string> KategoriIsimleri()
        {
            List<string> returnList = new List<string>();
            foreach (var item in DbFactory.KategoriCrud.Records)
            {
                returnList.Add(item.KategoriAdi);
            }
            return returnList;
        }
    }
}