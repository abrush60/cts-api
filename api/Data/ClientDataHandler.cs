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
                    clientFirstName = item.clientFirstName,
                    clientLastName = item.clientLastName,
                    clientPass = item.clientPass,
                    clientEmail = item.clientEmail,
                    phone = item.phone,
                };

                clients.Add(temp);
            }
            db.Close();

            return clients;
        }

         public void Delete(Client client)
         {
             string sql = "UPDATE client SET deleted= 'Y' WHERE eventId=@eventid";
            var values = GetValues(client);
            db.Open();
            db.Update(sql, values);
            db.Close();
         }

         public void Update(Client clients)
         {
            string sql = "UPDATE client SET clientFirstName=@clientFirstName, clientLastName=@clientLastName, clientPass=@clientPass clientEmail=@clientEmail, phone=@phone, ";
            sql += "WHERE eventId = @Id;";

            var values = GetValues(clients);
            db.Open();
            db.Update(sql, values);
            db.Close();
         }

         public void Insert(Client clients)
        {
            string sql = "INSERT INTO client (clientFirstName, clientLastName, clientPass, clientEmail, phone) ";
            sql += "VALUES (@clientFirstName, @clientLastName, @clientPass, @clientEmail, @phone)";

            var values = GetValues(clients);
            db.Open();
            db.Insert(sql, values);
            db.Close();
        }

        public Dictionary<string, object> GetValues(Client clients)
        {
            var values = new Dictionary<string, object>(){
                {"@clientId", clients.clientID},
                {"@clientFirstName", clients.clientFirstName},
                {"@clientLastName", clients.clientLastName},
                {"@clientPass", clients.clientPass},
                {"@clientEmail", clients.clientEmail},
                {"@clientPass", clients.clientPass}
            };

            return values;
        }
    }
}