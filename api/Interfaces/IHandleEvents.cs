using System.Dynamic;
using System.Collections.Generic;
using api.Interfaces;
using api.models;

namespace api.Interfaces
{
    public interface IHandleEvents
    {
         public List<Events> Select();

         public void Delete(Events person);

         public void Update(Events person);

         public void Insert(Events person);
    }
}