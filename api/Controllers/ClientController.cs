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
            Console.WriteLine(value);
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
        //PUT: for login needs link /api/Client/login
        [EnableCors("OpenPolicy")]
        [HttpPost("login")]
        public int Login([FromBody] Client value)
        {
            IHandleClients dataHandler = new ClientDataHandler();
            List <Client> myClient = dataHandler.Select();
            foreach (Client client in myClient)
            {
                if (client.clientEmail == value.clientEmail && client.clientPass == value.clientPass)
                {
                    return 1;
                }
                else 
                {
                    return 0;
                }
            }
            return 0;
        }
    }
}
