using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Models
{
    public class Choir
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public String Address { get; set; }


    }
}
