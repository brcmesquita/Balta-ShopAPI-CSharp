using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Models;

namespace Shop.Controllers
{
    [Route("v1")]
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<dynamic>> Get([FromServices] DataContext context)
        {
            var employee = new User { Id = 1, Username = "brcmesquita", Password = "123456", Role = "employee" };
            var manager = new User { Id = 2, Username = "raphael", Password = "123456", Role = "manager" };
            var category = new Category { Id = 1, Title = "Videogames" };
            var product = new Product { Id = 1, Category = category, Title = "Xbox One", Price = 1800, Description = "Videogame with 2 Wireless Controllers" };
            context.Users.Add(employee);
            context.Users.Add(manager);
            context.Categories.Add(category);
            context.Products.Add(product);
            await context.SaveChangesAsync();

            return Ok(new
            {
                message = "Dados configurados"
            });



        }
    }
}