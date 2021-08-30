using EmpactisTechTestWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmpactisTechTestWebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger _logger;

        public EmployeeController(IHttpClientFactory clientFactory, ILogger<EmployeeController> logger)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

        public IActionResult Index()
        {
            string employeeDataJson = RetrieveEmployeeAbsenceData().Result;

            IEnumerable<Employee> employees = JsonConvert.DeserializeObject<IEnumerable<Employee>>(employeeDataJson);

            return View(new EmployeeViewModel(employees));
        }

        public IActionResult AbsenceInformation(int employeeID)
        {
            List<Employee> employees = new List<Employee>();
            string employeeDataJson = RetrieveEmployeeAbsenceData(employeeID).Result;
            employees = JsonConvert.DeserializeObject<List<Employee>>(employeeDataJson);

            return View(employees[0]);
        }

        private Task<string> RetrieveEmployeeAbsenceData(int? id = null)
        {
            _logger.LogInformation("Starting request to API");
            var client = _clientFactory.CreateClient("EmpactisClient");

            if(!id.HasValue)
                return client.GetStringAsync($"api/Empactis/Get/Absences");

            return client.GetStringAsync($"api/Empactis/Get/Absences?employeeID={id}");
        }
    }
}
