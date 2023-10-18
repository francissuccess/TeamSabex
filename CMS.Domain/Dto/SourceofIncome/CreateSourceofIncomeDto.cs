using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Dto.SourceofIncome
{
    public class CreateSourceofIncomeDto
    {
        public decimal Offering { get; set; }
        public decimal Tithe { get; set; }
        public decimal Vow { get; set; }
        public string SalesofChurchItems { get; set; }
        public decimal donation { get; set; }
    }
}
