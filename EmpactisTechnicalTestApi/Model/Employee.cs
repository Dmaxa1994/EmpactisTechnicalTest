using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpactisTechnicalTestApi.Model
{
    public class Employee
    {
        public Employee() { }

        [Key]
        [Column("ID")]
        [Required]
        public int ID { get; set; }

        [Column("EmployeeNumber")]
        [Required]
        public int EmployeeNumber { get; set; }

        [Column("Name")]
        [Required]
        public string EmployeeName { get; set; }

        [Column("Department")]
        [Required]
        public string Department { get; set; }

        [NotMapped]
        public List<Absence> Absences { get; set; } = new List<Absence>();
    }
}
