using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Home
    {
        [Key]
        public int id { get; set; }
        public string username { get; set; }
        public int password { get; set; }
    }
}
