using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ApplicationPortal.Models
{
    public class Application
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public string ResumeName { get; set; }

        public Application() { }

        public Application(string name, string email, string phone, string status, string notes, string resumeName) {
            this.ID = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            this.Name = name;
            this.Phone = phone;
            this.Status = status;
            this.Notes = notes;
            this.ResumeName = resumeName;
        }
    }

    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("ApplicationContext")
        {
        }

        public DbSet<Application> Applications { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}