using BlazorApp1.Shared.Components.Models.NoteList;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteListDataController : ControllerBase
    {

        private readonly ILogger<NoteListDataController> _logger;

        public NoteListDataController(ILogger<NoteListDataController> logger)
        {
            _logger = logger;
        }

        // GET: api/<NoteListDataController>
        [Route("update")]
        [HttpGet]
        public IEnumerable<NoteListData> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new NoteListData
            {
                Icon = 0,
                Id = 1,
                Status = 2,
                Created = DateTime.Now.AddDays(index),
                Length = 60,
                Author = "Alex"
            }).ToArray();
        }

        // GET api/<NoteListDataController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NoteListDataController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<NoteListDataController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NoteListDataController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
