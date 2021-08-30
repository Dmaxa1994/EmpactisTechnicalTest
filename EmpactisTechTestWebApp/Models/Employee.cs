using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmpactisTechTestWebApp.Models
{
    public class Employee
    {
        public int ID { get; set; }

        public int EmployeeNumber { get; set; }

        public string EmployeeName { get; set; }

        public string Department { get; set; }

        public List<Absence> Absences { get; set; } = new List<Absence>();

        public int AbsenceCount => Absences.Count;
    }
}
