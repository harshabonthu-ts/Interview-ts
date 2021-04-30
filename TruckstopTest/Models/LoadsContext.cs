using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TruckstopTest.Models
{
    public class LoadsContext : DbContext
    {
        public LoadsContext(DbContextOptions<LoadsContext> options)
            : base(options)
        {
            SeedData();
        }

        public DbSet<Load> Loads { get; set; }

        private void SeedData()
        {
            var loads = new List<Load>();

            using (StreamReader sr = new StreamReader(@"path"))
            {
                string json = sr.ReadToEnd();
                loads = JsonConvert.DeserializeObject<List<Load>>(json);
            }

            this.AddRange(loads);
            this.SaveChanges();
        }
    }
}
