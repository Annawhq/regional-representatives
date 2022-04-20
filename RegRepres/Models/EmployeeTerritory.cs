using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegRepres.Models
{
    class EmployeeTerritory
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int TerritoryId { get; set; }
        public EmployeeTerritory() { }
        public EmployeeTerritory(int id, int employeeId, int territoryId)
        {
            this.Id = id;
            this.EmployeeId = employeeId;
            this.TerritoryId = territoryId;
        }
    }
}
