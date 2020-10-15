using EmployeeApp.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace EmployeeApp
{
    public abstract class ExportEmployees
    {
        public abstract void ExportEmplyees(List<Employee> employees);

        public const string FIRSTNAME = "First Name";
        public const string MIDDLEINITIAL = "Middle Initial";
        public const string LASTNAME = "Last Name";
        public const string CITY = "City";
        public const string STATE = "State";
        public const string ZIP = "Zip";
        public const string BONUS = "Bonus";

        public static DataTable CreateDataTable(List<Employee> employees)
        {
            DataTable table = new DataTable();

            table.Columns.Add(FIRSTNAME, typeof(string));
            table.Columns.Add(MIDDLEINITIAL, typeof(string));
            table.Columns.Add(LASTNAME, typeof(string));
            table.Columns.Add(CITY, typeof(string));
            table.Columns.Add(STATE, typeof(string));
            table.Columns.Add(ZIP, typeof(string));
            table.Columns.Add(BONUS, typeof(int));

            foreach (Employee employee in employees)
            {
                table.Rows.Add(employee.FirstName, employee.LastName, employee.City, employee.State, employee.Zip, employee.Bonus);
            }
            return table;
        }

        public static void ToCSV(DataTable dtDataTable, string strFilePath, string separator)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false);

            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(separator);
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(separator))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write(separator);
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }

    }
}
