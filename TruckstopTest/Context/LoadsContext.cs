using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using TruckstopTest.Models;

namespace TruckstopTest.Context
{
    public class LoadsContext : DbContext
    {
        public LoadsContext(DbContextOptions<LoadsContext> options)
            : base(options)
        {            
        }

        public DbSet<Load> Loads { get; set; }

        public void SeedData()
        {
            var loads = new List<Load>();

            using (StreamReader sr = new StreamReader("..\\loads.json"))
            {
                string json = sr.ReadToEnd();
                loads = JsonConvert.DeserializeObject<List<Load>>(json);
            }

            this.AddRange(loads);
            this.SaveChanges();
        }
    }
}
