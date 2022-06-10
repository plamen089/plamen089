using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class CarList : BaseEntity
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public string Years { get; set; }

        public string Description { get; set; }

        public int Prise { get; set; }


    }
}
