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

        public string package {get; set;}

        public int confirmed {get; set;}
        public int assigned {get; set;}
        public int dayOfStatus {get; set;}
        public int setupCompleted {get; set;}
        public int inProgress {get; set;}

        public int tearDown{get; set;}
        public int complete{get; set;}      

        public IHandleEvents eventHandler {get; set;}

        public Events(){
            eventHandler = new EventDataHandler();
        }
    }
}