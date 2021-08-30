# EmpactisTechnicalTest

EmpactisTechnicalTestApi
Visual Studio 2019 .NET 5.0
EF Core

Please note: The column names for the tables created by EF core are how they appear in the provided csvs
Please note: The database connection string will need to entered

The API uses HTTPGet to return data in JSON
Capable of returning a single employee, by their employee number or all employees

Future development:
- add full CRUD
   - Create to take in JSON from the body, able to process single item or a list for datadump
   - Update to extend a users current absence period
   - Delete to remove any items added by human error

***********************************************************************
EmpactisTechnicalTestWebApp
Visual Studio 2019 .NET 5.0 CSHtml

Uses IHttpClientFactory to get the list of employees
Displays all employees with amount of absence periods
Clicking an item will show the employee with more details about their absences

Future development:
- Add upload utility for CSV to convert to json
- Add Edit options to absences
- Add Delete options to absences
- Add Create option to absences
- Apply company house style in css