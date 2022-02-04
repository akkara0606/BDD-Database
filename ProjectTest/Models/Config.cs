using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProjectTest.Models
{
    public class  Config
    {
        public string ConfigSystem { get; set; }
        public string ConfigType { get; set; }
        public string ConfigCode { get; set; }
        public string ConfigDescript { get; set; }
    }
}
