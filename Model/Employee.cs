using api.Data;
using api.Interfaces;

namespace api.models
{
    public class Employee
    {
        public int employeeID { get; set; }
        public string Name { get; set; }
        public string employeePass { get; set; }
        public string employeeEmail { get; set; }
        public int IsAdmin { get; set; }

        public IHandleEmployees employeeHandler {get; set;}

        public Employee(){
            employeeHandler = new EmployeeDataHandler();
        }
    }
}