using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpactisTechTestWebApp.Models
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel(IEnumerable<Employee> employees)
        {
            Employees = employees;
        }

        public IEnumerable<Employee> Employees { get; set; } = new List<Employee>();
    }
}
