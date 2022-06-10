using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSevice.DTOc
{
    public class SellarDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int PhoneNumber { get; set; }

        public int CarListId { get; set; }
        public CarListDTO CarList { get; set; }
    }
}
