using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Monitoring.Models;

namespace Monitoring.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        public ITodoRepository TodoRepo {get;set;}
        public TodoController(ITodoRepository todoRepo) {
            TodoRepo = todoRepo;
        }
        // GET api/todo
        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            return TodoRepo.GetAll();
        }

        // GET api/todo/5
        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(string id)
        {
            var item = TodoRepo.Find(id);
            if (item != null) {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST api/todo
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/todo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/todo/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
