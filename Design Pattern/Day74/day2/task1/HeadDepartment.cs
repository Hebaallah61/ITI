using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace task1_Composite
{
    public class HeadDepartment:Department//composite class
    {
        private int id;
        private String name;
        private List<Department> childDepartments;
	    public HeadDepartment(int id, String name)
        {
            this.id = id;
            this.name = name;
            this.childDepartments = new List<Department>();
        }
        public void printDepartmentName()
        {
            foreach (Department department in this.childDepartments) {
                department.printDepartmentName();
            }
            
        }
        public void addDepartment(Department department)
        {
            childDepartments.Add(department);
        }
        public void removeDepartment(Department department)
        {
            childDepartments.Remove(department);
        }

    
    }
}
