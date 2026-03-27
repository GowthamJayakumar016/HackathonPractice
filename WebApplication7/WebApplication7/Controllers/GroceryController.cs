using Microsoft.AspNetCore.Mvc;
using WebApplication7.Data;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GroceryController : Controller
    {
        private readonly AppDbContext _context;
        public GroceryController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var grocery = _context.Groceries.ToList();
            return Ok(grocery);
        }
        [HttpGet("{id}")]
        public IActionResult GetAllbyid(int id)
        {
            var grocery = _context.Groceries.Find(id);
            if (grocery == null)
            {
                return NotFound();
            }
            return Ok(grocery);
        }
        [HttpPost]
        public IActionResult AddGrocery(Grocery grocery)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Groceries.Add(grocery);
            _context.SaveChanges();

            return Ok(grocery);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateGrocery(int id,Grocery grocery)
        {
            if (id != grocery.Id)
            {
                return BadRequest();
            }
            var exist = _context.Groceries.Find(id);
            if(exist ==null)
                return NotFound();
            exist.Name = grocery.Name;
            exist.Price = grocery.Price;
            _context.SaveChanges();
            return Ok(exist);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteGrocery(int id)
        {
            var grocery = _context.Groceries.Find(id);
            if(grocery== null)
                return NotFound();
            _context.Groceries.Remove(grocery);
            _context.SaveChanges();
            return Ok("deleted");
        }

    }
}
