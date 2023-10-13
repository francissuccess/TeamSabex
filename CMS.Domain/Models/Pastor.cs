using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Models
{
    public class Pastor : BaseEntity
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; } 
        public string Address { get; set; }
        public string Rank { get; set; }
        public string Description { get; set; }
    }
}
