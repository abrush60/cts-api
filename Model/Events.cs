using System.Dynamic;
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

        public bool confirmed {get; set;}
        public bool assigned {get; set;}
        public bool dayOfStatus {get; set;}
        public bool setupCompleted {get; set;}
        public bool inProgress {get; set;}

        public bool tearDown{get; set;}
        public bool complete{get; set;}      

        public IHandleEvents eventHandler {get; set;}

        public Events(){
            eventHandler = new EventDataHandler();
        }
    }
}