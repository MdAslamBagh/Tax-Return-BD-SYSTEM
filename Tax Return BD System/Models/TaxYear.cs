using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tax_Return_BD_System.Models
{
    public class TaxYear
    {
        public int TaxYearId { get; set; }
        public string Tax_Year { get; set; }
        public bool Default_Code { get; set; }

    }
}