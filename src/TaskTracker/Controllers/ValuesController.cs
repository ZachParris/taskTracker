using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Data;
using TaskTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using static TaskTracker.Models.ToDo;

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
       


        [HttpGet("{id}", Name = "GetToDo")]
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // returns a single ToDo 
                ToDo todo = context.ToDo.Single(m => m.Id == id);

                if (todo == null)
                {
                    return NotFound();
                }

                return Ok(todo);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }


        }

        [HttpGet("ByStatus/{status}")]
        public IActionResult ByStatus(int status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            try
            {
                IQueryable<ToDo> todos = context.ToDo.Where(t => t.Status == (ToDo.OrderStatus)status);
                return Ok(todos);
            }

            catch
            {
                return NotFound();
            }
        }


        // POST api/values/
        [HttpPost]
        public IActionResult Post([FromBody] ToDo todo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (todo.Status == OrderStatus.Completed)
            {
                todo.CompletedOn = DateTime.Now; 
            }

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
        public IActionResult Put(int id, [FromBody]ToDo todo)
        {

            if (todo.Id != id)
            {
                return BadRequest(ModelState);

            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (todo.Status == OrderStatus.Completed)
            {
                todo.CompletedOn = DateTime.Now;
            }

            try
            {

                context.Update(todo);
                context.SaveChanges();

            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        // DELETE api/values/5

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                ToDo todo = context.ToDo.Single(m => m.Id == id);

                if (todo == null)
                {
                    return NotFound();
                }
                context.ToDo.Remove(todo);
                context.SaveChanges();

                return Ok(todo);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }
        private bool ToDoExists(int id)
        {
            return context.ToDo.Count(e => e.Id == id) > 0;
        }
    }
}
