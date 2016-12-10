using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace JKEMVC.Models
{
    public class Udstillingsmodel
    {
        public int ID { get; set; }
        public string titel { get; set; }
        public string beskrivelse { get; set; }
        public string billedeSti { get; set; }
    }

    public class UdstillingsmodelDBContext : DbContext
    {
        public UdstillingsmodelDBContext() : base("UdstillingsmodelDBContext") { }
        public DbSet<Udstillingsmodel> Udstillingsmodels { get; set; }
    }
}