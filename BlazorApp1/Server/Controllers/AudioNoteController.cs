﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AudioNoteController : ControllerBase
    {
        // GET: api/<AudioNoteController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AudioNoteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AudioNoteController>
        [Route("ready")]
        [HttpPost]
        public void PostReady([FromBody] string value)
        {

        }

        // POST api/<AudioNoteController>
        [Route("suspend")]
        [HttpPost]
        public void PostSuspend([FromBody] string value)
        {

        }

        // PUT api/<AudioNoteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AudioNoteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
