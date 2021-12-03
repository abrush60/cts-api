using System.Collections.Generic;
using api.models;

namespace api.Interfaces
{
    public interface IHandleEmployees
    {
         public List<Employee> Select();

        public void Delete(Employee employee);

        public void Update(Employee employee);

        public void Insert(Employee employee);
    }
}