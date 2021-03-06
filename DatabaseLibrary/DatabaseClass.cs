﻿using System;
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

        public DataTable DataTable { private set; get; }

        public DataRow DataRow { private set; get; }

        public DatabaseClass(string databaseName)
        {

            this.DatabaseConnection = new SqlConnection(@"Data Source=SURFACEBOOK\DEV_ENVIRONMENT;Initial Catalog=" + databaseName + ";Integrated Security=True");

        }

        public string GetDataTable(string selectStatement)
        {

            if (DatabaseConnection.State == ConnectionState.Closed)
            {
                DatabaseConnection.Open();
            }

            if (selectStatement == null || selectStatement == string.Empty)
            {
                return "Invalid sql statement. Please provide a valid sql select statement.";
            }

            this.DatabaseCommand = new SqlCommand(selectStatement, DatabaseConnection);

            this.SqlDataAdapter = new SqlDataAdapter(DatabaseCommand);

            DataTable = new DataTable();

            this.SqlDataAdapter.Fill(DataTable);

            DatabaseConnection.Close();

            return "";

        }

        public string GetDataRow(string selectStatement)
        {

            string message = GetDataTable(selectStatement); //if you get a message with a length of greater than zero then there is an error.

            DataRow = DataTable.Rows[0];

            return "";
            
        }

        public int InsertRow(string insertStatement)
        {

            int numberOfRows = 0;

            if (DatabaseConnection.State == ConnectionState.Closed)
            {
                DatabaseConnection.Open();
            }

            using (this.DatabaseCommand = new SqlCommand(insertStatement, DatabaseConnection))
            {

                numberOfRows = this.DatabaseCommand.ExecuteNonQuery();

            }

            return numberOfRows;
            
        }

    }
}
