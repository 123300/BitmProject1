using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Management_System__Sales_Module_.Model
{
    public class SaleDetails
    {
        public List<SaleDetails> saleDetails = new List<SaleDetails>();
       
        
        public int Id { set; get; }
        public string Category { set; get; }
        public string ProductCode { set; get; }
        public string AvailableQuantity { set; get; }
        public string Quantity { set; get; }
        public double MrpTk { set; get; }
        public double TotalMrpTk { set; get; }
    
           
    }
}
