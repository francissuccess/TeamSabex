using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Models
{
    public class BaseEntity
    {
        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public string? ModifiedBy { get; set; }
        public bool isDeleted { get; set; }

    }
}
