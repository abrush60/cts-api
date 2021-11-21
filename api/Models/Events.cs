using api.Interfaces;
using api.Data;

namespace api.Model
{
    public class Events
    {
        public int Id {get; set;}
        public string Name {get; set;}

        public IHandleEvents eventHandler {get; set;}

        public Events(){
            eventHandler = new EventDataHandler();
        }
    }
}