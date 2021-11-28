using System.Collections.Generic;
using api.models;

namespace api.Interfaces
{
    public interface IHandleClients
    {
        public List<Client> Select();

        public void Delete(Client person);

        public void Update(Client person);

        public void Insert(Client person);
    }
}