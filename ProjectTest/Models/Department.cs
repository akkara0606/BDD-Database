using System.Collections.Generic;

namespace ProjectTest.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public  List<Document> Document { get; set; }
    }
}