using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace DatabaseLibrary
{

    public class DatabaseClass
    {

        private SqlConnection DatabaseConnection { set; get; }

        private SqlCommand DatabaseCommand { set; get; }

        private SqlDataAdapter SqlDataAdapter { set; get; }


        public DatabaseClass()
        {

            this.DatabaseConnection = new SqlConnection("Data Source=Lenovo-T440s\\MSSQLSERVER01;Initial Catalog=AdventureWorks2017;Integrated Security=True");

        }

        public DataTable GetDataTable(string selectStatement)
        {

            if (DatabaseConnection.State == ConnectionState.Closed)
            {
                DatabaseConnection.Open();
            }

            this.DatabaseCommand = new SqlCommand(selectStatement, DatabaseConnection);

            this.SqlDataAdapter = new SqlDataAdapter(DatabaseCommand);

            DataTable dataTable = new DataTable();

            this.SqlDataAdapter.Fill(dataTable);

            DatabaseConnection.Close();

            return dataTable;

        }

        public DataRow GetDataRow(string selectStatement)
        {

            DataTable dataTable = GetDataTable(selectStatement);

            DataRow dataRow = dataTable.Rows[0];

            return dataRow;
            
        }

    }
}
