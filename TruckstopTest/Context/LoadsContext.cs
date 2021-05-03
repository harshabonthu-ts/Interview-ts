using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System;
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

            var path = Path.Combine(Environment.CurrentDirectory, "loads.json");

            using (StreamReader sr = new StreamReader(path))
            {
                string json = sr.ReadToEnd();
                loads = JsonConvert.DeserializeObject<List<Load>>(json);
            }

            this.AddRange(loads);
            this.SaveChanges();
        }
    }
}
