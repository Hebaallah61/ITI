using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstructorWPF.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Branches { get; set; }
        public string? Location { get; set; }
        public virtual ICollection<Instructor>? Instructors { get; set; }
    }
}
