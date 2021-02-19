using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sale_EFChapter3.Models
{

    public class Sale
    {
        public int SaleId { get; set; }
        public string ProductName { get; set; }
        public double Amount { get; set; }
        public DateTime SalesDate { get; set; }

        public int CustomerId { get; set; }
        
        public Customer Customer { get; set; }
    }

}
