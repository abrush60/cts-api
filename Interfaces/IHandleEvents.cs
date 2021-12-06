using System.Dynamic;
using System.Collections.Generic;
using api.Interfaces;
using api.models;

namespace api.Interfaces
{
    public interface IHandleEvents
    {
         public List<Events> Select();

         public void Delete(Events events);

         public void Update(Events events);

         public void Insert(Events events);

         public void UpdateStatus(Events events);
    }
}