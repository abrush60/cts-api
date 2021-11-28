using System.Collections.Generic;
using System.Dynamic;
using api.models;
using api.Interfaces;

namespace api.Data
{
    public class ClientDataHandler : IHandleClients
    {
        private Database db;
        public ClientDataHandler()
        {
            db = new Database();
        }
        public List<Client> Select()
        {
            db.Open();
            string sql = "SELECT * from client";
            List<ExpandoObject> results = db.Select(sql);

            List<Client> clients = new List<Client>();
            foreach(dynamic item in results)
            {
                Client temp = new Client(){
                    clientID = item.clientID,
                    clientName = item.clientName,
                    clientPass = item.clientPass,
                    clientEmail = item.clientEmail,
                    clientPhone = item.clientPhone,
                };

                clients.Add(temp);
            }

            return clients;
        }

         public void Delete(Client clients)
         {

         }

         public void Update(Client clients)
         {
             
         }

         public void Insert(Client clients)
        {
            string sql = "INSERT INTO event (clientID, clientName, clientPass, clientEmail, clientPass) ";
            sql += "VALUES (@clientID, @clientName, @clientPass, @clientEmail, @clientPass)";

            var values = GetValues(clients);
            db.Open();
            db.Insert(sql, values);
            db.Close();
        }

        public Dictionary<string, object> GetValues(Client clients)
        {
            var values = new Dictionary<string, object>(){
                {"@clientId", clients.clientID},
                {"@clientName", clients.clientName},
                {"@clientPass", clients.clientPass},
                {"@clientEmail", clients.clientEmail},
                {"@clientPass", clients.clientPass}
            };

            return values;
        }
    }
}