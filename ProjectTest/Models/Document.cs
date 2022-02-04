using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using System.ComponentModel; 

namespace ProjectTest.Models
{
    public class Document
    {
        public string No { get; set; }
        public string RQE { get; set; }
        public string Name { get; set; }
        public string Nameproj { get; set; }
        public string Department { get; set; }
        public string Responsible { get; set; }
        public string Locker { get; set; }
        public DateTime Tdate { get; set; }
        public string Year { get; set; }
        public string Uploader { get; set; }
        
        
    }
}
