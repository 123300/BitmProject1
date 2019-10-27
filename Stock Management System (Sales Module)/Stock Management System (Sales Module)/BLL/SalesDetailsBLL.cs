using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Stock_Management_System__Sales_Module_.Model;
using Stock_Management_System__Sales_Module_.Repository;

namespace Stock_Management_System__Sales_Module_.BLL
{
    public class SalesDetailsBLL
    {
        SalesDetailsRepository _salesDetailsRepository = new SalesDetailsRepository();

           public bool SubmitButton(SaleDetails saleDetails)
           {
               return _salesDetailsRepository.SubmitButton(saleDetails);
           } 

        public List<SaleDetails> DisplaySalesItem()
        {
            return _salesDetailsRepository.DisplaySalesItem();
        }

        public bool Update(SaleDetails saleDetails)
        {
            return _salesDetailsRepository.Update(saleDetails);
        }

        public DataTable ClickSubmit(SaleDetails saleDetails)
        {
            return _salesDetailsRepository.ClickSubmit(saleDetails);
        }

        public DataTable Search(SaleDetails saleDetails)
        {
            return _salesDetailsRepository.Search(saleDetails);
        }
    }
}
