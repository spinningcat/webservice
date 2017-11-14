using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NWSolution.Models
{
    public class SessionToken
    {
        [Key] // Define primary key
        public Guid SessionID { get; set; }

        [StringLength(16)] // varchar(16)
        public string Token { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
