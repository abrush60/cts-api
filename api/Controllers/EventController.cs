using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Model;
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
            IHandleEvents dataHandler = new EventDataHandler();
            return dataHandler.Select();
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
            //value.datahandler.Insert(value);
        }

        // PUT: api/Events/5
        [EnableCors("OpenPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Events value)
        {
            //value.datahandler.Update(value);
        }

        // DELETE: api/Events/5
        [EnableCors("OpenPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // Events value = new Events(){Id = id};
            // value.datahandler.Delete(value);
        }
    }
}
