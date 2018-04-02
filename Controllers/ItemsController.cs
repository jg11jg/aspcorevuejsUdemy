using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Vue2Spa.Data;
using Vue2Spa.Models;

namespace Vue2Spa.Controllers
{

    [Route("api/[controller]")]
    public class ItemsController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private ItemsManager manager;
        public ItemsController(IConfiguration config, ApplicationDbContext context) : base(config)
        {
            _context = context;
            manager = new ItemsManager(configuration);
        }
        // GET: api/Items
        [HttpGet]
        public List<Items> Get()
        {
            return _context.Items.ToList();
        }

        // GET: api/Items/5
        [HttpGet("{id}", Name = "Get")]
        public Items Get(int id)
        {
            return _context.Items.Find(id);
        }

        // POST: api/Items
        [HttpPost]
        public Items Post([FromBody]Items value)
        {
            _context.Items.Add(value);
            _context.SaveChanges();
            return value;
        }

        // PUT: api/Items
        [HttpPut]
        public Items Put([FromBody]Items value)
        {
            _context.Items.Update(value);
            _context.SaveChanges();
            return value;
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            _context.Items.Remove(_context.Items.Find(id));
            _context.SaveChanges();
            return id;
        }
    }
}
