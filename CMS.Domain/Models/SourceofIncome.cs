using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Models
{
    public class SourceofIncome : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public decimal Offering { get; set; }
        public decimal Tithe { get; set; }
        public decimal Vow { get; set; }
        public string SalesofChurchItems { get; set; }
        public decimal donation { get; set; }   

    }
}
