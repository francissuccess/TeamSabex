using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Dto.Choir
{
    public class UpdateChoirDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Areaofspecialization { get; set; }
        public string PhoneNumber { get; set; }
    }
}
