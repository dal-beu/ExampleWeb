using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiExample.Database;

namespace ApiExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListItemController(ListContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListItem>>> GetListItems()
        {
            return await context.ListItems.ToListAsync();
        }

        // GET: api/ListItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ListItem>> GetListItem(int id)
        {
            var listItem = await context.ListItems.FindAsync(id);

            if (listItem == null)
            {
                return NotFound();
            }

            return Ok(listItem);
        }

        // PUT: api/ListItem/5
        // To protect from over posting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutListItem(int id, ListItem listItem)
        {
            if (id != listItem.Id)
            {
                return BadRequest();
            }

            context.Entry(listItem).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListItemExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // POST: api/ListItem
        // To protect from over posting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ListItem>> PostListItem(ListItem listItem)
        {
            context.ListItems.Add(listItem);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetListItem", new { id = listItem.Id }, listItem);
        }

        // DELETE: api/ListItem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListItem(int id)
        {
            var listItem = await context.ListItems.FindAsync(id);
            if (listItem == null)
            {
                return NotFound();
            }

            context.ListItems.Remove(listItem);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool ListItemExists(int id)
        {
            return context.ListItems.Any(e => e.Id == id);
        }
    }
}
