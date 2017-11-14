using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWSolution.DTO
{

    public class NWSolutionDTO // data transfer object
    {
        public int NWID { get; set; }
        public string LATITUDE { get; set; }
        public string LONGITUDE { get; set; }
        public string PROBLEMTYPE { get; set; }
        public string PROBLEMTYPEID { get; set; }
        public string PROBLEMDATE { get; set; }
        public string PROBLEMNOTE { get; set; }
        public string USERNAME { get; set; }
        public string USEREMAIL { get; set; }
        public string USERPHONENUMBER { get; set; }
        public string USERDEVICETYPE { get; set; }
        public string USERDEVICEVERSION { get; set; }
        public string DEVICEOSVERSION { get; set; }
        public string REPORTDATE { get; set; }
        public string NETWORKTYPE { get; set; }
        
    }
}


