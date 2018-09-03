namespace ApplicationPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applications", "File", c => c.String(nullable: false));
            DropTable("dbo.FileUploads");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FileUploads",
                c => new
                    {
                        File = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.File);
            
            DropColumn("dbo.Applications", "File");
        }
    }
}
