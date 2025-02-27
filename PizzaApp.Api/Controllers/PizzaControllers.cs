using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaApp.Api.Infrastructure;
using PizzaApp.Api.Models;

namespace PizzaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly PizzaContext _context;

        public PizzaController(PizzaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pizza>>> GetPizzas()
        {
            return await _context.Pizzas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pizza>> GetPizza(int id)
        {
            var pizza = await _context.Pizzas.FindAsync(id);
            if (pizza == null) return NotFound();
            return pizza;
        }

        [HttpPost]
        public async Task<ActionResult<Pizza>> PostPizza(Pizza pizza)
        {
            _context.Pizzas.Add(pizza);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPizza), new { id = pizza.Id }, pizza);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPizza(int id, Pizza pizza)
        {
            if (id != pizza.Id) return BadRequest();
            _context.Entry(pizza).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePizza(int id)
        {
            var pizza = await _context.Pizzas.FindAsync(id);
            if (pizza == null) return NotFound();
            _context.Pizzas.Remove(pizza);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
