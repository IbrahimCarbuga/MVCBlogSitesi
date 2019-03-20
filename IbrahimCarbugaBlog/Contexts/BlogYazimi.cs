namespace IbrahimCarbugaBlog
{
    using IbrahimCarbugaBlog.Entity;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BlogYazimi : DbContext
    {      
        public BlogYazimi()
            : base("name=BlogYazimi")
        {
        }
        
        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Gonderi> Gonderiler { get; set; }
        public virtual DbSet<Kategori> Kategoriler { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Yorum> Yorumlar { get; set; }
    }

    
}