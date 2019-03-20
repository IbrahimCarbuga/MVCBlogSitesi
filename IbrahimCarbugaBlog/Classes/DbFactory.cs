using IbrahimCarbugaBlog.Entity;
using OhmCrud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IbrahimCarbugaBlog.Classes
{
    public static class DbFactory
    {
        private static volatile BlogYazimi _db = new BlogYazimi();
        private static volatile GenelCrud<User> _userCrud = null;
        public static GenelCrud<User> UserCrud
        {
            get
            {
                if (_userCrud == null)
                {
                    _userCrud = new GenelCrud<User>(_db, _db.Users);
                    _userCrud.CheckConnection();
                }
                return _userCrud;
            }
        }

        private static volatile GenelCrud<Gonderi> _gonderiCrud = null;
        public static GenelCrud<Gonderi> GonderiCrud
        {
            get
            {
                if (_gonderiCrud == null)
                {
                    _gonderiCrud = new GenelCrud<Gonderi>(_db, _db.Gonderiler);
                    _gonderiCrud.CheckConnection();
                }
                return _gonderiCrud;
            }
        }

        private static volatile GenelCrud<Kategori> _kategoriCrud = null;
        public static GenelCrud<Kategori> KategoriCrud
        {
            get
            {
                if (_kategoriCrud == null)
                {
                    _kategoriCrud = new GenelCrud<Kategori>(_db, _db.Kategoriler);
                    _kategoriCrud.CheckConnection();
                }
                return _kategoriCrud;
            }
        }

        private static volatile GenelCrud<Yorum> _yorumCrud = null;
        public static GenelCrud<Yorum> YorumCrud
        {
            get
            {
                if (_yorumCrud == null)
                {
                    _yorumCrud = new GenelCrud<Yorum>(_db, _db.Yorumlar);
                    _yorumCrud.CheckConnection();
                }
                return _yorumCrud;
            }
        }

    }
}