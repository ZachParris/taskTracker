using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Data;
using TaskTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace TaskTracker.Controllers
{

    [ProducesAttribute("application/json")]

    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private BangazonContext context;

        public ValuesController(BangazonContext ctx)
        {
            context = ctx;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<object> todos = from todo in context.ToDo select todo;

            if (todos == null)
            {
                return NotFound();
                //NotFound() is a helper function. It is a valid 404 response back to the client. 
            }

            return Ok(todos);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

       

        [HttpPost]

        //   !ModelState is comparing against all your annotations, etc. 

        public IActionResult Post([FromBody] ToDo todo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // 
            context.ToDo.Add(todo);

            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ToDoExists(todo.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetToDo", new { id = todo.Id }, todo);
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

        private bool ToDoExists(int id)
        {
            return context.ToDo.Count(e => e.Id == id) > 0;
        }
    }
}
