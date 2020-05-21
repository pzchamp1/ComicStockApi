using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ComicStock.Models;

namespace ComicStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ComicStockContext _context;

        public SuppliersController(ComicStockContext context)
        {
            this._context = context;

            // if (_context.Suppliers.Count() == 0)
            // {
            //     _context.Suppliers.Add(
            //         new Supplier
            //         {
            //             Id = 546,
            //             Name = "Guns and Roses",
            //             City = "Dubai",
            //             Reference = "32425453453"
            //         }
            //     );
            //     _context.SaveChanges();
            // }
        }

        // GET api/supplier
        [HttpGet]
        public ActionResult<IEnumerable<Supplier>> Get()
        {
            return _context.Suppliers.ToList();
        }

        // GET api/suppliers/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/supplier
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/supplier/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/supplier/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
