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

        public sbyte confirmed {get; set;}
        public sbyte assigned {get; set;}
        public sbyte dayOfStatus {get; set;}
        public sbyte setupCompleted {get; set;}
        public sbyte inProgress {get; set;}

        public sbyte tearDown{get; set;}
        public sbyte complete{get; set;}

        public string kera { get; set; }        

        public IHandleEvents eventHandler {get; set;}

        public Events(){
            eventHandler = new EventDataHandler();
        }
    }
}