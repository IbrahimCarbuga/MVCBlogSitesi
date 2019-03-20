namespace IbrahimCarbugaBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vers1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gonderis",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Baslik = c.String(),
                        Icerik = c.String(),
                        OlusturmaTarihi = c.DateTime(nullable: false),
                        OlusturanKisi = c.String(maxLength: 50),
                        GuncellemeTarihi = c.DateTime(nullable: false),
                        GuncelleyenKisi = c.String(maxLength: 50),
                        Kategori_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Kategoris", t => t.Kategori_ID)
                .Index(t => t.Kategori_ID);
            
            CreateTable(
                "dbo.Kategoris",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        KategoriAdi = c.String(),
                        OlusturmaTarihi = c.DateTime(nullable: false),
                        OlusturanKisi = c.String(maxLength: 50),
                        GuncellemeTarihi = c.DateTime(nullable: false),
                        GuncelleyenKisi = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Yorums",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        YorumIcerigi = c.String(),
                        GecerliMi = c.Boolean(nullable: false),
                        OlusturmaTarihi = c.DateTime(nullable: false),
                        OlusturanKisi = c.String(maxLength: 50),
                        GuncellemeTarihi = c.DateTime(nullable: false),
                        GuncelleyenKisi = c.String(maxLength: 50),
                        User_ID = c.String(maxLength: 128),
                        Gonderi_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .ForeignKey("dbo.Gonderis", t => t.Gonderi_ID)
                .Index(t => t.User_ID)
                .Index(t => t.Gonderi_ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Ad = c.String(),
                        Soyad = c.String(),
                        KullaniciAdi = c.String(),
                        Sifre = c.String(),
                        Email = c.String(),
                        DogumTarihi = c.DateTime(nullable: false),
                        UserType = c.Int(nullable: false),
                        OlusturmaTarihi = c.DateTime(nullable: false),
                        OlusturanKisi = c.String(maxLength: 50),
                        GuncellemeTarihi = c.DateTime(nullable: false),
                        GuncelleyenKisi = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Yorums", "Gonderi_ID", "dbo.Gonderis");
            DropForeignKey("dbo.Yorums", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Gonderis", "Kategori_ID", "dbo.Kategoris");
            DropIndex("dbo.Yorums", new[] { "Gonderi_ID" });
            DropIndex("dbo.Yorums", new[] { "User_ID" });
            DropIndex("dbo.Gonderis", new[] { "Kategori_ID" });
            DropTable("dbo.Users");
            DropTable("dbo.Yorums");
            DropTable("dbo.Kategoris");
            DropTable("dbo.Gonderis");
        }
    }
}
