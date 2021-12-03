using MySql.Data.MySqlClient;
using api.interfaces;

namespace api.database
{
    public interface DeleteClient : IDeleteClient
    {
        // public static void DropClientTable()
        // {
        //     ConnectionString myConnection = new ConnectionString();
        //     string cs = myConnection.cs;

        //     using var con = new MySqlConnection(cs);
        //     con.Open();

        //     string stm = @"DROP TABLE IF EXISTS clients";

        //     using var cmd = new MySqlCommand(stm, con);

        //     cmd.ExecuteNonQuery();
        // }
        //  void IDeleteClient.DeleteClient(string userName)
        //  {
        //     throw new System.NotImplementedException();
        //  }
    }
}