namespace ApplicationPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Status = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FileUploads",
                c => new
                    {
                        File = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.File);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FileUploads");
            DropTable("dbo.Applications");
        }
    }
}
