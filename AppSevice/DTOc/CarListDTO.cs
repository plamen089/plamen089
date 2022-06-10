using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSevice.DTOc
{
    public class CarListDTO
    {
        public int Id { get; set; }

        public  string Brand { get; set; }

        public string Model { get; set; }

        public string Years { get; set; }

        public string Description { get; set; }

        public int Prise { get; set; }

        public  bool Validate()
        {
            return !String.IsNullOrEmpty(Brand);
        }
    }
}
