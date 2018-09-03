namespace ApplicationPortal.Migrations
{
    using ApplicationPortal.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationPortal.Models.ApplicationDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationPortal.Models.ApplicationDBContext context)
        {
            //  This method will be called after migrating to the latest version.
            context.Applications.AddOrUpdate(i => i.Name,
                new Application
                {
                    Name = "Fangzhu Li",
                    Email = "fangzli@umich.edu",
                    Phone = "7348810720"
                }
            );
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
