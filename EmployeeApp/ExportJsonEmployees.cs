using EmployeeApp.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp
{
    public class ExportJsonEmployees : ExportEmployees
    {        
        private string FILENAME = @"d:\employee.json";
             
        public override void ExportEmplyees(List<Employee> employees)
        {
            JSONSerilaize(employees);
        }

        private void JSONSerilaize(List<Employee> employees)
        {
            using StreamWriter file = File.CreateText(FILENAME);
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, employees);
        }
    }
}
