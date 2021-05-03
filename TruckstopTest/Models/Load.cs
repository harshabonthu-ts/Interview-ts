using System;
using System.ComponentModel.DataAnnotations;

namespace TruckstopTest.Models
{
    public class Load
    {        
        [Key]
        public Guid Id { get; set; }
    }
}
