using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NWSolution.Models
{
    public class NW
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string user_name { get; set; }
        public string Latitude { get; set; }
        public string Longtitude { get; set; }
        public string user_devicetype { get; set; }
        public string user_email { get; set; }
        public string user_phonenumber { get; set; }
        public string user_deviceversion { get; set; }
        public string deviceosversion { get; set; }
        public string problem_date { get; set; }
        public string problem_note { get; set; }
        public string problem_type { get; set; }
        public string report_date { get; set; }
        public string network { get; set; }

    }
}
