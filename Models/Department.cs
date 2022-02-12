using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string Comment { get; set; }

        public ICollection<Employee> Employee { get; set; }
    }
}
