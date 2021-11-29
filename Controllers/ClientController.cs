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
    public class ClientController : ControllerBase
    {
        // GET: api/Client
        [EnableCors("OpenPolicy")]
        [HttpGet]
        public List<Client> Get()
        {
            IHandleClients dataHandler = new ClientDataHandler();
            return dataHandler.Select();
        }

        // GET: api/Client/5
        [EnableCors("OpenPolicy")]
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Client
        [EnableCors("OpenPolicy")]
        [HttpPost]
        public void Post([FromBody] Client value)
        {
            value.clientHandler.Insert(value);
        }

        // PUT: api/Client/5
        [EnableCors("OpenPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Client value)
        {
            value.clientHandler.Update(value);
        }

        // DELETE: api/Client/5
        [EnableCors("OpenPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Client value = new Client(){clientID = id};
            value.clientHandler.Delete(value);
        }
    }
}
