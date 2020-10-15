using System.Collections.Generic;
using EmployeeApp.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeManager _manager;

        public EmployeeController(IEmployeeManager manager)
        {
            _manager = manager;
        }     

        [HttpPost]
        public void ExportData([FromBody] List<Employee> employees, [FromBody] FileTypeEnum fileType)
        {
            _manager.ExportFile(employees, fileType);
        }
    }
}
