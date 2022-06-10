using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Buyer : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Mony { get; set; }

        public int CarListId { get; set; }
        public virtual CarList CarList { get; set; }
    }
}
