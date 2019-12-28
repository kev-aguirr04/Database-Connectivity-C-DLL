using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLibrary;
using System.Data;

namespace ExerciseConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            DatabaseClass dbClass = new DatabaseClass();

            string errorMessage = dbClass.GetDataTable("select * from Person.Person where BusinessEntityID = 1");

            if (errorMessage.Length > 0)
            {
                Console.WriteLine(errorMessage);
            }
            else
            {
                if (dbClass.DataTable.Rows.Count > 0)
                {
                    for (int counter = 0; counter < dbClass.DataTable.Rows.Count; counter++)
                    {
                        for (int columnCount = 0; columnCount < dbClass.DataTable.Columns.Count; columnCount++)
                        {

                            Console.Write(dbClass.DataTable.Rows[counter].ItemArray[columnCount].ToString() + " ");

                        }
                    }
                }
                
            }

        }
    }
}
