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
    public class SalesRepository
    {
        public bool AddButton(Sale _sale)
        {
            bool isAdded = false;
            //Connection

            string connectionString = @"Server =LAPTOP-JECDIQLU; Database=Project1DB; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command

            string commandString = @"INSERT INTO Sales(Id,Date,CustomerCode,LoyalityPoint) VALUES(" + _sale.Id+","+_sale.Date+",'"+_sale.CustomerCode+"',"+_sale.LoyalityPoint+")";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();


            int isExecuted = sqlCommand.ExecuteNonQuery();
            if (isExecuted > 0)
            {
                isAdded = true;
            }
           

            sqlConnection.Close();
            return isAdded;


           
        }

        public DataTable LoadCustomer()
        {
            
            //Connection

            string connectionString = @"Server =LAPTOP-JECDIQLU; Database=Project1DB; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command

            string commandString = @"SELECT Id,CustomerCode FROM  Sales";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            
            
            sqlConnection.Close();
            return dataTable;
        

       

        }
        public DataTable LoadProduct()
        {

            //Connection

            string connectionString = @"Server =LAPTOP-JECDIQLU; Database=Project1DB; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command

            string commandString = @"SELECT Id,ProductCode FROM  SalesDetails";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);


            sqlConnection.Close();
            return dataTable;




        }
        public DataTable LoadCategory()
        {

            //Connection

            string connectionString = @"Server =LAPTOP-JECDIQLU; Database=Project1DB; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command

            string commandString = @"SELECT Id,Category FROM  SalesDetails";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);


            sqlConnection.Close();
            return dataTable;




        }
    }
}