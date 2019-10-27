using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Stock_Management_System__Sales_Module_.Model;

namespace Stock_Management_System__Sales_Module_.Repository
{
    public class SalesDetailsRepository
    {
        public bool SubmitButton(SaleDetails saleDetails)
        {
            bool isSubmitted = false;
            //Connection
            string connectionString = @"Server=LAPTOP-JECDIQLU; Database=Project1DB; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 

            string commandString = @"INSERT INTO SalesDetails(Category,ProductCode,AvailableQuantity,Quantity,MrpTk,TotalMrpTk) VALUES('" + saleDetails.Category + "','" + saleDetails.ProductCode + "','" + saleDetails.AvailableQuantity + "','" + saleDetails.Quantity + "','" + saleDetails.MrpTk + "','" + saleDetails.TotalMrpTk + "')";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            int isExecuted = sqlCommand.ExecuteNonQuery();
            if (isExecuted > 0)
            {
                isSubmitted = true;
            }
            //Close
            sqlConnection.Close();
            return isSubmitted;


        }

        public List<SaleDetails> DisplaySalesItem()
        {
            List<SaleDetails> salesDetails = new List<SaleDetails>();

            string connectionString = @"Server=LAPTOP-JECDIQLU; Database=Project1DB; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            string query = "SELECT * FROM SalesDetails";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {

                SaleDetails saleDetail = new SaleDetails();

                saleDetail.ProductCode = sqlDataReader["ProductCode"].ToString();
                saleDetail.Quantity = (sqlDataReader["Quantity"]).ToString();
                saleDetail.MrpTk = Convert.ToDouble(sqlDataReader["MrpTk"]);
                saleDetail.TotalMrpTk = Convert.ToDouble(sqlDataReader["TotalMrpTk"]);


                salesDetails.Add(saleDetail);
            }
            sqlConnection.Close();

            return salesDetails;
        }

        public bool Update(SaleDetails saleDetails)
        {
            bool isUpdated = false;
            //Connection
            string connectionString = @"Server=LAPTOP-JECDIQLU; Database=Project1DB; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 

            string commandString = @"Update  SalesDetails set Quantity='" + saleDetails.Quantity + "' where AvailableQuantity='" + saleDetails.AvailableQuantity + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            int isExecuted = sqlCommand.ExecuteNonQuery();
            if (isExecuted > 0)
            {
                isUpdated = true;
            }
            //Close
            sqlConnection.Close();
            return isUpdated;


        }

        public DataTable ClickSubmit(SaleDetails saleDetails)
        {

            //Connection
            string connectionString = @"Server=LAPTOP-JECDIQLU; Database=Project1DB; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 

            string commandString = @"SELECT * FROM SalesDetails";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Show
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);


            sqlConnection.Close();
            return dataTable;

        }

        public DataTable Search(SaleDetails saleDetails)
        {

            //Connection
            string connectionString = @"Server=LAPTOP-JECDIQLU; Database=Project1DB; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 

            string commandString = @"SELECT * FROM SalesDetails Where ProductCode='"+saleDetails.ProductCode+"' AND (AvailableQuantity='"+saleDetails.AvailableQuantity+"')";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Show
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);


            sqlConnection.Close();
            return dataTable;

        }






    }
}