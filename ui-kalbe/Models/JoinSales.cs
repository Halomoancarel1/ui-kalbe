using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ui_kalbe.Models
{
    public class JoinSales
    {
        public int id { get; set; }
        public Nullable<double> qty { get; set; }
        public String customerName { get; set; }

        public List<customer> listCustomer { get; set; }
    }

    public class customer
    {
        public int customerId { get; set; }
        public String customerName { get; set; }
    }
}