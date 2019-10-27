using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Management_System__Sales_Module_.Model
{
    public class Sale
    {
        public int Id { set; get; }
        public string Date { set; get; }
        public string CustomerCode { set; get; }
       
        public double LoyalityPoint { set; get; }
        

    }
}
