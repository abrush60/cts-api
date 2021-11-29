using System.Collections.Generic;
using api.models;

namespace api.Interfaces
{
    public interface IHandleClients
    {
        public List<Client> Select();

        public void Delete(Client client);

        public void Update(Client client);

        public void Insert(Client client);
    }
}