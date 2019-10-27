using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Stock_Management_System__Sales_Module_.Model;
using Stock_Management_System__Sales_Module_.Repository;

namespace Stock_Management_System__Sales_Module_.BLL
{
    public class SalesBLL
    {
        SalesRepository _salesRepository = new SalesRepository();
        public bool AddButton(Sale _sale)
        {
            return _salesRepository.AddButton(_sale);
        }

        public DataTable LoadCustomer()
        {
            return _salesRepository.LoadCustomer();
            
        }
        public DataTable LoadCategory()
        {
            return _salesRepository.LoadCategory();
        }
        public DataTable LoadProduct()
        {
            return _salesRepository.LoadProduct();
        }
    }
}
