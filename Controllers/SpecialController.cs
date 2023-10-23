using BlazingPizzaSite.Data;
using BlazingPizzaSite.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazingPizzaSite.Controllers
{
    [Route("Specials")]
    [ApiController]
    public class SpecialController : Controller
    {
        private readonly PizzaStoreContext _db;

        public SpecialController(PizzaStoreContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<PizzaSpecial>>> GetSpecials()
        {
            var _list = await _db.Specials.ToListAsync();
            return _list.OrderByDescending(p => p.BasePrice).ToList();
        }
    }
}
