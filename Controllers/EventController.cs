using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        // GET: api/Events
        [EnableCors("OpenPolicy")]

        [HttpGet]
        public List<Events> Get()
        {
            IHandleEvents eventHandler = new EventDataHandler();
            return eventHandler.Select();
        }

        // GET: api/Events/5
        [EnableCors("OpenPolicy")]
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Events
        [EnableCors("OpenPolicy")]
        [HttpPost]
        public void Post([FromBody] Events value)
        {
            value.eventHandler = new EventDataHandler();
            value.eventHandler.Insert(value);
        }

        // PUT: api/Events/5
        [EnableCors("OpenPolicy")]
        [HttpPut]
        public void Put([FromBody] Events value)
        {
            Console.WriteLine("confirmed" + value.confirmed);
            Console.WriteLine("assigned" + value.assigned);
            Console.WriteLine("eventId" + value.eventId);
           value.eventHandler = new EventDataHandler();
            value.eventHandler.Update(value);
        }

        // PUT: api/Events/status
        [EnableCors("OpenPolicy")]
        [HttpPut("status")]

        public void PutStatus([FromBody] Events value)
        {
             Console.WriteLine("confirmed" + value.confirmed);
            Console.WriteLine("assigned" + value.assigned);
            Console.WriteLine("eventId" + value.eventId);
           value.eventHandler = new EventDataHandler();
            value.eventHandler.UpdateStatus(value);
        }

        // DELETE: api/Events/5
        [EnableCors("OpenPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Events value = new Events(){eventId = id};
            value.eventHandler.Delete(value);
        }
    }
}
