using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpactisTechnicalTestApi.Model
{
    public class Absence
    {
        public Absence() { }

        [Key]
        [Column("ID")]
        [Required]
        public int ID { get; set; }

        [Column("EmployeeId")]
        [Required]
        public int EmployeeNumber { get; set; }

        [Column("Start", TypeName = "datetime")]
        [Required]
        public DateTime StartDate { get; set; }

        [Column("End", TypeName = "datetime")]
        [Required]
        public DateTime EndDate { get; set; }

        [Column("Type")]
        [Required]
        public int AbsenceType { get; set; }
    }
}
