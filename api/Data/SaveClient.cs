namespace api.database
{
    public class SaveClient : ISaveClient
    {
        public void CreateClient(Client myClient)
        {
            ConnectionString myConnection = new ConnectionString();
                string cs = myConnection.cs;
                using var con = new MySqlConnection(cs);
                con.Open();

                string stm = @"INSERT INTO client(email, userName) VALUES(@email, @userName)";
                using var cmd = new MySqlCommand(stm, con);

                cmd.Parameters.AddWithValue("@email", myClient.email);
                cmd.Parameters.AddWithValue(@"Text", myClient.userName);
                
                cmd.Prepare();
                cmd.ExecuteNonQuery();
        }
        public static void CreateClientTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"CREATE TABLE client(email TEXT PRIMARY KEY AUTO_INCREMENT, userName TEXT, clientPassword TEXT, phone TEXT)";

            using var cmd = new MySqlCommand(stm, con);
            cmd.ExecuteNonQuery();
        }
        void ISaveClient(Client myClient)
            {
                throw new System.NotImplementedException();
            }
            void ISaveClient.SaveClient(Client myClient)
            {
                throw new NotImplementedException();
            }
    }
}