using System.Collections.Generic;
using System.Dynamic;
using api.models;
using api.Interfaces;

namespace api.Data
{
    public class EmployeeDataHandler : IHandleEmployees
    {
        private Database db;

        public EmployeeDataHandler()
        {
            db = new Database();
        }

        public void Delete(Employee employee)
        {
            string sql = "UPDATE employee SET deleted= 'Y' WHERE employeeId=@employeeId";
            var values = GetValues(employee);
            db.Open();
            db.Update(sql, values);
            db.Close();
        }

        public void Insert(Employee employee)
        {
            string sql = "INSERT INTO employee (employeeID, Name, employeePass, employeeEmail, IsAdmin) ";
            sql += "VALUES (@employeeID, @Name, @employeePass, @employeeEmail, @IsAdmin)";

            var values = GetValues(employee);
            db.Open();
            db.Insert(sql, values);
            db.Close();
        }

        public List<Employee> Select()
        {
            db.Open();
            string sql = "SELECT * from employee";
            List<ExpandoObject> results = db.Select(sql);

            List<Employee> employees = new List<Employee>();
            foreach(dynamic item in results)
            {
                Employee temp = new Employee(){
                    employeeID = item.employeeId,
                    Name = item.Name,
                    employeePass = item.employeePass,
                    employeeEmail = item.employeeEmail,
                    IsAdmin = item.IsAdmin
                };

                employees.Add(temp);
            }
            db.Close();
            return employees;
        }

        public void Update(Employee employee)
        {
            string sql = "UPDATE event SET employeeID=@employeeID, Name=@Name, employeePass=@employeePass, employeeEmail=@employeeEmail, IsAdmin=@IsAdmin, ";
            sql += "WHERE eventId = @Id;";

            var values = GetValues(employee);
            db.Open();
            db.Update(sql, values);
            db.Close();
        }

        public Dictionary<string, object> GetValues(Employee employee)
        {
            var values = new Dictionary<string, object>(){
                {"@employeeID", employee.employeeID},
                {"@Name", employee.Name},
                {"@employeePass", employee.employeePass},
                {"@employeeEmail", employee.employeeEmail},
                {"@IsAdmin", employee.IsAdmin},
            };

            return values;
        }
    }
}