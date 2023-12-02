using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_דוטנט
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private static int count = 0;

        private static List<Event> _events = new List<Event> { new Event { Id = ++count, Title = "default", Start =DateTime.Today, End = DateTime.Today} };

        // GET: api/<EventsController>
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return _events;
        }

        // POST api/<EventsController>
        [HttpPost]
        public void Post([FromBody] Event eve)
            
        {
            
            _events.Add(new Event { Id = ++count, Title = eve.Title, Start=eve.Start,End=eve.End });
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event eve)
        {
            var eve1 = _events.Find(e => e.Id == id);
            {
                eve1.Title = eve.Title;
                eve1.Start = eve.Start;
                eve1.End = eve.End;
            };
         
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var eve = _events.Find(e => e.Id == id);
          
           _events.Remove(eve);

        }
    }
}
