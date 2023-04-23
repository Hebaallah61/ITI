using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.BL.Dtos.Developers;
using Tickets.BL.Dtos.Tickets;

namespace Tickets.BL.Managers.Developers;

public interface IDevelopersManager
{
    IEnumerable<DeveloperDto> GetAll();
    DeveloperDto? GetById(int[] id);
}
