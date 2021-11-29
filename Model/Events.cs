using api.Interfaces;
using api.Data;

namespace api.models
{
    public class Events
    {
        public int eventId {get; set;}
        public int employeeId {get; set;}
        public int clientId {get; set;}

        public string clientEmail {get; set;}

        public IHandleEvents eventHandler {get; set;}

        public Events(){
            eventHandler = new EventDataHandler();
        }
    }
}