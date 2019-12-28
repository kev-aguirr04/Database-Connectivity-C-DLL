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

            DataRow dataRow = dbClass.GetDataRow("select * from Person.Person where BusinessEntityID = 1");

            foreach (object scalarValue in dataRow.ItemArray)
            {
                Console.WriteLine(scalarValue.ToString());
            }

        }
    }
}
