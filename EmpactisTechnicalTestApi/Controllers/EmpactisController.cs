using EmpactisTechnicalTestApi.Data;
using EmpactisTechnicalTestApi.Interfaces;
using EmpactisTechnicalTestApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpactisTechnicalTestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpactisController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly ILogger<EmpactisController> _logger;
        public EmpactisController(IRepository repository,
            ILogger<EmpactisController> logger)
        {
            _logger = logger;
            _repository = repository;
        }

        /// <summary>
        /// Gets the employee and absence records
        /// Allows the user to enter an ID
        /// </summary>
        /// <param name="employeeID">Nullable, ID for the employee, if null returns all</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Get/Absences")]
        public async Task<ActionResult<IEnumerable<ActionResult>>> GetEmployeesAbsences(int? employeeID)
        {
            _logger.LogInformation("GetEmployeesAbsences request");
            List<Absence> absences = await _repository.SelectAll<Absence>();
            List<Employee> employees = await _repository.SelectAll<Employee>();

            if (employeeID.HasValue)
            {
                employees = employees.Where(x => x.EmployeeNumber == employeeID).ToList();
            }

            if (employees == null || absences == null)
            {
                _logger.LogError("End of request: statuscode 500");
                return StatusCode(500);
            }

            if (employees.Count == 0)
            {
                _logger.LogInformation("End of request: statuscode 402");
                return NoContent();
            }

            foreach (Employee employee in employees)
            {
                employee.Absences = absences.Where(x => x.EmployeeNumber == employee.EmployeeNumber).ToList();
            }

            string employeeJson = JsonConvert.SerializeObject(employees, Formatting.Indented);

            _logger.LogInformation("End of request: statuscode 200");
            return Ok(employeeJson);
        }
    }
}
