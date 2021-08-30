using EmpactisTechnicalTestApi.Controllers;
using EmpactisTechnicalTestApi.Interfaces;
using EmpactisTechnicalTestApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace EmpactisTechnicalTestAPIUnitTests
{
    public class EmpactisControllerUnitTests
    {
        [Fact]
        public async Task GetEmployeesAbsences_ServerError_Absences()
        {
            var repositoryStub = new Mock<IRepository>();
            repositoryStub.Setup(repo => repo.SelectAll<Employee>()).ReturnsAsync(new List<Employee>());

            var loggerStub = new Mock<ILogger<EmpactisController>>();

            var controller = new EmpactisController(repositoryStub.Object, loggerStub.Object);

            var result = await controller.GetEmployeesAbsences(null);

            Assert.Equal(500, (result.Result as StatusCodeResult).StatusCode);
        }

        [Fact]
        public async Task GetEmployeesAbsences_ServerError_Employees()
        {
            var repositoryStub = new Mock<IRepository>();
            repositoryStub.Setup(repo => repo.SelectAll<Absence>()).ReturnsAsync(new List<Absence>());

            var loggerStub = new Mock<ILogger<EmpactisController>>();

            var controller = new EmpactisController(repositoryStub.Object, loggerStub.Object);

            var result = await controller.GetEmployeesAbsences(null);

            Assert.Equal(500, (result.Result as StatusCodeResult).StatusCode);
        }

        [Fact]
        public async Task GetEmployeesAbsences_NoContent()
        {
            var repositoryStub = new Mock<IRepository>();
            repositoryStub.Setup(repo => repo.SelectAll<Employee>()).ReturnsAsync(new List<Employee>());
            repositoryStub.Setup(repo => repo.SelectAll<Absence>()).ReturnsAsync(new List<Absence>());

            var loggerStub = new Mock<ILogger<EmpactisController>>();

            var controller = new EmpactisController(repositoryStub.Object, loggerStub.Object);

            var result = await controller.GetEmployeesAbsences(null);

            Assert.Equal(204, (result.Result as StatusCodeResult).StatusCode);
        }


        [Fact]
        public async Task GetEmployeesAbsences_OK_All()
        {
            List<Employee> expected = new List<Employee>()
            {
                new Employee()
                {
                    Department = "Dev",
                    EmployeeName = "First Last",
                    EmployeeNumber = 1
                },
                new Employee()
                {
                    Department = "Marketing",
                    EmployeeName = "First Last",
                    EmployeeNumber = 2
                }
            };

            var repositoryStub = new Mock<IRepository>();
            repositoryStub.Setup(repo => repo.SelectAll<Employee>()).ReturnsAsync(expected);
            repositoryStub.Setup(repo => repo.SelectAll<Absence>()).ReturnsAsync(new List<Absence>());

            var loggerStub = new Mock<ILogger<EmpactisController>>();

            var controller = new EmpactisController(repositoryStub.Object, loggerStub.Object);

            var result = await controller.GetEmployeesAbsences(null);

            Assert.IsType<OkObjectResult>(result.Result);

            string expectedJson = JsonConvert.SerializeObject(expected, Formatting.Indented);

            Assert.Equal(expectedJson, (result.Result as OkObjectResult).Value);
        }

        [Fact]
        public async Task GetEmployeesAbsences_OK_WithID()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee()
                {
                    Department = "Dev",
                    EmployeeName = "First Last",
                    EmployeeNumber = 1
                },
                new Employee()
                {
                    Department = "Marketing",
                    EmployeeName = "First Last",
                    EmployeeNumber = 2
                }
            };

            List<Employee> expected = new List<Employee>()
            {
                new Employee()
                {
                    Department = "Marketing",
                    EmployeeName = "First Last",
                    EmployeeNumber = 2
                }
            };

            var repositoryStub = new Mock<IRepository>();
            repositoryStub.Setup(repo => repo.SelectAll<Employee>()).ReturnsAsync(employees);
            repositoryStub.Setup(repo => repo.SelectAll<Absence>()).ReturnsAsync(new List<Absence>());

            var loggerStub = new Mock<ILogger<EmpactisController>>();

            var controller = new EmpactisController(repositoryStub.Object, loggerStub.Object);

            var result = await controller.GetEmployeesAbsences(2);

            Assert.IsType<OkObjectResult>(result.Result);

            string expectedJson = JsonConvert.SerializeObject(expected, Formatting.Indented);

            Assert.Equal(expectedJson, (result.Result as OkObjectResult).Value);
        }
    }
}
