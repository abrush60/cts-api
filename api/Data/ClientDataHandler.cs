namespace api.Data
{
    public class ClientDataHandler
    {
        private Database db;
        public ClientDataHandler()
        {
            db = new Database();
        }
        public List<Clients> Select()
        {
            db.Open();
            string sql = "SELECT * from client";
            List<ExpandoObject> results = db.Select(sql);

            List<Clients> events = new List<Clients>();
            foreach(dynamic item in results)
            {
                Clients temp = new Clients(){
                    clientID = item.clientID,
                    clientName = item.clientName,
                    clientPass = item.clientPass,
                    clientEmail = item.clientEmail,
                    clientPhone = item.clientPhone,
                };

                events.Add(temp);
            }

            return clients;
        }

         public void Delete(Clients clients)
         {

         }

         public void Update(Clients clients)
         {
             
         }

         public void Insert(Clients clients)
        {
            string sql = "INSERT INTO event (clientID, clientName, clientPass, clientEmail, clientPass) ";
            sql += "VALUES (@clientID, @clientName, @clientPass, @clientEmail, @clientPass)";

            var values = GetValues(clients);
            db.Open();
            db.Insert(sql, values);
            db.Close();
        }
    }
}