using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stock_Management_System__Sales_Module_.Model;
using Stock_Management_System__Sales_Module_.BLL;

namespace Stock_Management_System__Sales_Module_
{
    
    public partial class Sales : Form
    {
        public List<string> CategoryCombo = new List<string> { };
        SalesBLL _salesBLL = new SalesBLL();
        SalesDetailsBLL _saleDetailsBLL = new SalesDetailsBLL();

        

        string customerCombo = "";
        string categoryCombo = "";
        string productCombo = "";
        double total=0;
        public Sales()
        {
            InitializeComponent();
        }

       

        private void AddButton_Click(object sender, EventArgs e)
        {
            Sale _sale = new Sale();

             if(String.IsNullOrEmpty(dateTimePicker1.Text))
            {
                MessageBox.Show("Select dateTimePicker");
                return;
            }

            try
            {
                customerCombo = customerComboBox.SelectedValue.ToString();

                if (Convert.ToInt32(customerCombo) <= 0)
                {
                    MessageBox.Show("Please,, Select any Customer..");
                    return;
                }
            }
            catch (Exception exception)
            {
                
                MessageBox.Show("Please,, Select any Customer..");
                return;
            }

            try
            {
                categoryCombo = categoryComboBox.SelectedValue.ToString();

                if (Convert.ToInt32(categoryCombo) <= 0)
                {
                    MessageBox.Show("Please,, Select any Category..");
                    return;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Please,, Select any Category..");
                return;
            }

            try
            {
                productCombo = productComboBox.SelectedValue.ToString();

                if (Convert.ToInt32(productCombo) <= 0)
                {
                    MessageBox.Show("Please,, Select any Product..");
                    return;
                }
            }
            catch (Exception exception)
            {
                
                MessageBox.Show("Please,, Select any Product..");
                return;
            }

            if (quantityTextBox.Text == "")
            {
                MessageBox.Show("Quantity field is requirde..");
                return;
            }

            if(mrpTextBox.Text =="")
            {
                MessageBox.Show("Mrp field is required");
                return;
            }

            if(totalMrpTextBox.Text =="")
            {
                MessageBox.Show("totalMrp field is required");
                return;
            }
          

            _salesBLL.AddButton(_sale); 

            
         
                salesDataGridView.Visible = true;
                submitDataGridView.Visible = false;
                MessageBox.Show("Added successfully");

           
            int row = 0;
            salesDataGridView.Rows.Add();
            row = salesDataGridView.Rows.Count-2;
            salesDataGridView["CustomerCode", row].Value = customerComboBox.Text;
            salesDataGridView["Date", row].Value = dateTimePicker1.Text;
            salesDataGridView["LoyalityPoint", row].Value = loyalityPointTextBox.Text;
            salesDataGridView["Category", row].Value = categoryComboBox.Text;
            salesDataGridView["Product", row].Value = productComboBox.Text;
            salesDataGridView["Available", row].Value = availableQuantityTextBox.Text;
            salesDataGridView["Qnty",row].Value = quantityTextBox.Text;
            salesDataGridView["mrp", row].Value = mrpTextBox.Text;
            salesDataGridView["TotalMrp", row].Value = totalMrpTextBox.Text; 

            total = total + Convert.ToDouble(totalMrpTextBox.Text);
            grandTotalTextBox.Text = total.ToString();

            double loyalityPoint = total / 1000;
            loyalityPointTextBox.Text = loyalityPoint.ToString();

            double discount = loyalityPoint / 10;
            discountTextBox.Text = discount.ToString();

            double discountAmount = total * discount / 100;
            discountAmountTextBox.Text = discountAmount.ToString();

            double payableAmount = total - discountAmount;
            payableAmountTextBox.Text = payableAmount.ToString();
          

           

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Sales_Load(object sender, EventArgs e)
        {
            customerComboBox.DataSource = _salesBLL.LoadCustomer();
            categoryComboBox.DataSource = _salesBLL.LoadCategory();
            productComboBox.DataSource = _salesBLL.LoadProduct();
            
        }

        private void SalesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           if(e.RowIndex >=0)
            {
                DataGridViewRow row = this.submitDataGridView.Rows[e.RowIndex];
                productComboBox.Text = row.Cells["prdct"].Value.ToString();
                quantityTextBox.Text = row.Cells["quantity"].Value.ToString();
                mrpTextBox.Text = row.Cells["mrptk"].Value.ToString();
                totalMrpTextBox.Text = row.Cells["totalmrptk"].Value.ToString();
            }


        } 

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if(totalMrpTextBox.Text=="")
            {
                MessageBox.Show("totalMrpText field is required");
                    return;
            }

            if (mrpTextBox.Text == "")
            {
                MessageBox.Show("MrpText field is required");
                return;
            }

            if (availableQuantityTextBox.Text == "")
            {
                MessageBox.Show("AvailableText field is required");
                return;
            }
          

            SaleDetails saleDetails = new SaleDetails();
            

            salesDataGridView.Visible = false;
            submitDataGridView.Visible = true;
            MessageBox.Show("Added successfully in the GridView..!!");


            saleDetails.Category=(categoryComboBox.Text).ToString();
            saleDetails.ProductCode = (productComboBox.Text).ToString();
            saleDetails.Quantity = (quantityTextBox.Text);
            saleDetails.TotalMrpTk = Convert.ToDouble(totalMrpTextBox.Text);
            saleDetails.MrpTk = Convert.ToDouble(mrpTextBox.Text);
            saleDetails.AvailableQuantity = availableQuantityTextBox.Text;

               _saleDetailsBLL.SubmitButton(saleDetails);
          

            submitDataGridView.DataSource = _saleDetailsBLL.ClickSubmit(saleDetails);



        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            MessageBox.Show(dateTimePicker1.Text.ToString());
        }

        private void ProductComboBox_Leave(object sender, EventArgs e)
        {
            availableQuantityTextBox.Text = productComboBox.SelectedValue.ToString();
            

        }

        private void AvailableQuantityTextBox_Leave(object sender, EventArgs e)
        {
           
        }

        private void ProductComboBox_Click(object sender, EventArgs e)
        {
            

            //_saleDetailsBLL.Search(saleDetails);
        }

        private void SubmitDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.submitDataGridView.Rows[e.RowIndex];
                productComboBox.Text = row.Cells["prdct"].Value.ToString();
                quantityTextBox.Text = row.Cells["quantity"].Value.ToString();
                mrpTextBox.Text = row.Cells["mrptk"].Value.ToString();
                totalMrpTextBox.Text = row.Cells["totalmrptk"].Value.ToString();
            }
        }
    }
}
