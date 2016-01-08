using Microsoft.AspNet.WebHooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi_Hooks.Models;

namespace WebApi_Hooks.Controllers
{
    [RoutePrefix("api/instagram")]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        [Route("subscribe")]
        public async Task<IHttpActionResult> PostSubscribe()
        {
            // Get our WebHook Client
            InstagramWebHookClient client = Dependencies.Client;

            

            var s =new Uri( "https://7136dbf1.ngrok.io");

            // Subscribe to a geo location, in this case within 5000 meters of Times Square in NY
            var sub = await client.SubscribeAsync(string.Empty, s, 40.757626, -73.985794, 5000);

            return Ok(sub);
        }

    }
}
