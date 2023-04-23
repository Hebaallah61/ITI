using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.BL.Dtos.Departments;

namespace Tickets.BL.Managers.Departments;

public interface IDepartmentsManager
{
    IEnumerable<DepartmentsreadDto> GetAll();
}
