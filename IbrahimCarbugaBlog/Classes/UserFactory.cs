using IbrahimCarbugaBlog.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IbrahimCarbugaBlog.Classes
{
    public static class UserFactory
    {
        public static string SuperSecretKey = "123456";
        public static User GetCurrentUser(string cookieValue)
        {
            string decryptedId = OhmCryptor.OhmCryptor.Decrypt(cookieValue, SuperSecretKey);
            return DbFactory.UserCrud.Find(decryptedId);
        }
    }
}