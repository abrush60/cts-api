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
    public class ReviewController : ControllerBase
    {
        // GET: api/Review
        [EnableCors("OpenPolicy")]
        [HttpGet]
        public List<Review> Get()
        {
            IHandleReviews dataHandler = new ReviewDataHandler();
            return dataHandler.Select();
        }

        // GET: api/Review/5
        [EnableCors("OpenPolicy")]
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Review
        [EnableCors("OpenPolicy")]
        [HttpPost]
        public void Post([FromBody] Review value)
        {
            value.reviewHandler.Insert(value);
        }

        // PUT: api/Review/5
        [EnableCors("OpenPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Review value)
        {
            value.reviewHandler.Update(value);
        }

        // DELETE: api/Review/5
        [EnableCors("OpenPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Review value = new Review(){reviewId = id};
            value.reviewHandler.Delete(value);
        }
    }
}
