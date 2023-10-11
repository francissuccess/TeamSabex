using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Dto.Pastor
{
    public class UpdatePastorDto
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Rank { get; set; }
        public object Description { get; set; }
    }
}
