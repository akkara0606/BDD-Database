using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProjectTest.Models
{
    public class Employee
    {
        public string Employee_id { get; set; }
        public string Emp_Password { get; set; }    
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surename { get; set; }
        public string Contact_number { get; set; }

    }
}
