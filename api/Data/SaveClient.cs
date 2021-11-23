using api.Data;
using api.interfaces;
using api.models;
using MySql.Data.MySqlClient;

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

            string stm = @"CREATE TABLE client(clientEmail TEXT PRIMARY KEY AUTO_INCREMENT, clientName TEXT, userName TEXT, clientPassword TEXT, phone TEXT)";

            using var cmd = new MySqlCommand(stm, con);
            cmd.ExecuteNonQuery();
        }

        public void SaveBook(Client myClient)
        {
            return;
        }
        void ISaveClient(Client myClient)
            {
                throw new System.NotImplementedException();
            }
            void ISaveClient.SaveClient(Client myClient)
            {
                throw new System.NotImplementedException();
            }
    }
}