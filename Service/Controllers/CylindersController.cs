using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CylindersController : ControllerBase
    {
        // GET: api/Cylinders
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Cylinders/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // GET: api/Cylinders/MaxRec/200/100/10/5/10
        [HttpGet("MaxRec/{length}/{width}/{radius}/{minDistC2C}/{minDistC2Edge}", Name = "GetMaxNumberOfCylindersRecPattern")]
        public string GetMaxNumberOfCylindersRecPattern(int length, int width, int radius, int minDistC2C, int minDistC2Edge)
        {
            /*using (var db = new DatabaseLogger())
            {
                var requestInfo = new RequestInfo { Url = "http://sample.com", Time = DateTime.Now.ToString() };
                db.RequestsInfo.Add(requestInfo);
                db.SaveChanges();
            }*/

            Tape tape = new Tape(length, width);
            Rondelica rondelica = new Rondelica(radius, minDistC2C, minDistC2Edge, new Point());
            return tape.MaxNumberOfCylindersRecPattern(rondelica).ToString();
        }

        // GET: api/Cylinders/MaxTriangle/200/100/10/5/10
        [HttpGet("MaxTriangle/{length}/{width}/{radius}/{minDistC2C}/{minDistC2Edge}", Name = "GetMaxNumberOfCylindersTrianglePattern")]
        public string GetMaxNumberOfCylindersTrianglePattern(int length, int width, int radius, int minDistC2C, int minDistC2Edge)
        {
            Tape tape = new Tape(length, width);
            Rondelica rondelica = new Rondelica(radius, minDistC2C, minDistC2Edge, new Point());
            return tape.MaxNumberOfCylindersTriangularPattern(rondelica).ToString();
        }

        // GET: api/Cylinders/PositionsRec/200/100/10/5/10
        [HttpGet("PositionsRec/{length}/{width}/{radius}/{minDistC2C}/{minDistC2Edge}", Name = "GetPositionsOfCylindersRecPattern")]
        public string GetPositionsOfCylindersRecPattern(int length, int width, int radius, int minDistC2C, int minDistC2Edge)
        {
            Tape tape = new Tape(length, width);
            Rondelica rondelica = new Rondelica(radius, minDistC2C, minDistC2Edge, new Point());
            return JsonConvert.SerializeObject(tape.GetPositionsOfCylindersRecPattern(rondelica));
        }

        // GET: api/Cylinders/PositionsTriangle/200/100/10/5/10
        [HttpGet("PositionsTriangle/{length}/{width}/{radius}/{minDistC2C}/{minDistC2Edge}", Name = "GetPositionsOfCylindersTriangularPattern")]
        public string GetPositionsOfCylindersTriangularPattern(int length, int width, int radius, int minDistC2C, int minDistC2Edge)
        {
            Tape tape = new Tape(length, width);
            Rondelica rondelica = new Rondelica(radius, minDistC2C, minDistC2Edge, new Point());
            return JsonConvert.SerializeObject(tape.GetPositionsOfCylindersTriangularPattern(rondelica));
        }

        // POST: api/Cylinders
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Cylinders/5
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
