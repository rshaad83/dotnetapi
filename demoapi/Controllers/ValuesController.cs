using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using  static System.Net.Http.HttpResponseMessage;

namespace demoapi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        
        [HttpGet("toUpper/{message}")]
        public string convertToUpperCase(string message)
        { 
            String upper = message.ToUpper();
            return "Upper Case Value: " + upper;
        }

         [HttpGet("toLower/{message}")]
        public string convertToLowerCase(string message)
        { 
           String errorProne = null;

            errorProne.ToUpper();

            return "Lower Case Value: " + message.ToLower();
        }

        [HttpPost("register")]
        public System.Net.Http.HttpResponseMessage register([FromBody]string name, [FromBody]String email)
        {
            System.Net.Http.HttpResponseMessage response = new System.Net.Http.HttpResponseMessage();

            response.StatusCode = HttpStatusCode.OK;
            response.ReasonPhrase = "Acknowledged receipt of POST request for name: " + name + ", email: " + email;
            return response;
        }


        [HttpGet("slow")]
        public String slowRequest(string value)
        {
            //Generate random sleeptime
            Random waitTime = new Random();
            int timeInMs = waitTime.Next(2, 15) * 100;
            //Put the thread to sleep
            System.Threading.Thread.Sleep(timeInMs);
            return "API call took " + timeInMs + " milli seconds to execute";

        }



        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
