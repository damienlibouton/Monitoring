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
        public IEnumerable<TodoItem> GetAll() {
            return TodoRepo.GetAll();
        }

        // GET api/todo/5
        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(string id) {
            var item = TodoRepo.Find(id);
            if (item == null) {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST api/todo
        [HttpPost]
        public IActionResult Create([FromBody]TodoItem item) {
            if (item == null) {
                return BadRequest();
            }
            TodoRepo.Add(item);
            return CreatedAtRoute("GetTodo", new {id = item.Key}, item);
        }

        // PUT api/todo/5
        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody]TodoItem item) {
            if (item == null || id != item.Key) {
                return BadRequest();
            }
            var todo = TodoRepo.Find(id);
            if (todo == null) {
                return NotFound();
            }
            TodoRepo.Update(item);
            return new NoContentResult();
        }

        // DELETE api/todo/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id) {
            var todo = TodoRepo.Find(id);
            if (todo == null) {
                return NotFound();
            }
            TodoRepo.Remove(id);
            return new NoContentResult();
        }
    }
}
