using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegRepres.Models
{
    class Territory
    {
        public int Id { get; set; }
        public int RegionId { get; set; }
        public string Discription { get; set; }
        public Territory() { }
        public Territory(int id, int regionId, string discription)
        {
            this.Id = id;
            this.RegionId = regionId;
            this.Discription = discription;
        }
    }
}
