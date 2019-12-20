using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmailCounts
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        public int GetUniqueEmailCounts(string[] emails)
        {
            var result = new Dictionary<string, int>();
            foreach (var e in emails)
            {
                var eId = e.Split('@');
                var reqId = eId[0].ToLower().Replace(".", "").Split('+')[0];
                if (!result.ContainsKey(reqId + "@" + eId[1]))
                    result.Add(reqId + "@" + eId[1], 1);
            }

            return result.Count;
        }
    }
}
