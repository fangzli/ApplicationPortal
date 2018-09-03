using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ApplicationPortal.Models
{
    public class Application
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
    }

    public class ApplicationDBContext : DbContext
    {
        public DbSet<Application> Applications { get; set; }
    }
}