using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegRepres.Models
{
    class Region
    {
        public int Id { get; set; }
        public string RegionDiscription { get; set; }
        public Region() { }
        public Region(int id, string regionDiscription)
        {
            this.Id = id;
            this.RegionDiscription = regionDiscription;
        }

    }
}
