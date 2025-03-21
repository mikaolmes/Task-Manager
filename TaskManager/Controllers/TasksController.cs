using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Models;
using System.Threading.Tasks; // Für den Namespace des asynchronen Tasks

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult> GetAllTasks()
        {
            var tasks = await _context.Tasks.ToListAsync();
            return Ok(tasks);
        }


        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }



        [HttpPost]
        public async Task<ActionResult> PostTask(TodoTask task) // Hier TodoTask statt Task verwenden
        {
            try
            {
                _context.Tasks.Add(task);
            }
            catch
            {
                return Conflict();
            }
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }


        // PUT: api/Tasks/5
        [HttpPut("{id}")]
public async Task<ActionResult> PutTask(int id, [FromBody] TodoTask task)
{
    if (id != task.Id)
    {
        return BadRequest();
    }

    _context.Entry(task).State = EntityState.Modified;
    try
    {
        await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!_context.Tasks.Any(p => p.Id == id))
        {
            return NotFound();
        }
        else
        {
            throw;
        }
    }
    return NoContent();
}


        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTask(int id)
        {
            var movie = await _context.Tasks.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(movie);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}