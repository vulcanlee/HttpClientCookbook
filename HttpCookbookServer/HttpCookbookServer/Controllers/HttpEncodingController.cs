using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HttpCookbookServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HttpEncodingController : ControllerBase
    {
        // GET: api/HttpEncoding
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/HttpEncoding/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/HttpEncoding
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/HttpEncoding/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
