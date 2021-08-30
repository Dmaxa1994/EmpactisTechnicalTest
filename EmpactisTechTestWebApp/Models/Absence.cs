using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmpactisTechTestWebApp.Models
{
    public class Absence
    {
        public int ID { get; set; }

        public int EmployeeNumber { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int AbsenceType { get; set; }

        private int GetTotalDaysInAbsencePeriod()
        {
            return (EndDate - StartDate).Days;
        }

        public string StartDateDisplay => DisplayForDate(StartDate);
        public string EndDateDisplay => DisplayForDate(EndDate);

        private string DisplayForDate(DateTime date)
        {
            return date.Date.ToShortDateString();
        }

        public int TotalDaysInAbsencePeriod => GetTotalDaysInAbsencePeriod();
    }
}
