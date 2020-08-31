using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Csharp.OOD.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Csharp.OOD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CacheController : ControllerBase
    {
        private readonly ILogger<CacheController> _logger;
        private readonly LRUCache _cache;
        public CacheController(ILogger<CacheController> logger, ICache cache) 
        {
            this._logger = logger;
            this._cache = (LRUCache)cache;
        }

        // GET: api/<CacheController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CacheController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return this._cache.Get(id);
        }

        // POST api/<CacheController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CacheController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            this._cache.Put(id, value);
        }

        // DELETE api/<CacheController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
