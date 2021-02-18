using BlazorApp1.Server.Components;
using BlazorApp1.Shared.Components.Models.Account;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorApp1.Server.Controllers
{
    // the Uri to her is "api/" is the first part of the path, "[controller]" points to this controller class
    // and the third points to the given function
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        // GET: api/<LoginController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoginController>
        [HttpPost]
        [Route("login")]
        public Object Post([FromBody] LoginData login)
        {
            ServicesAccess s = new ServicesAccess();
            var result = s.CallServiceRefLogin(login.Username, login.Password);

            Console.WriteLine("Server/LoginController.cs: " + result);

            return result;
        }

        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
