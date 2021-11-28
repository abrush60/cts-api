using api.Data;
using api.Interfaces;

namespace api.models
{
    public class Client
    {
        public int clientID { get; set; }
        public string clientName { get; set; }
        public string clientPass { get; set; }
        public string clientEmail { get; set; }
        public string clientPhone { get; set; }

        public IHandleClients clientHandler {get; set;}

        public Client(){
            clientHandler = new ClientDataHandler();
        }
    }
}