using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagement.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InventoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/Item
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listInventories = await _context.Items.ToListAsync();
                return Ok(listInventories);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Item/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Item
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Item value)
        {
            try
            {
                _context.Add(value);
                await _context.SaveChangesAsync();
                return Ok(value);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Item/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Item value)
        {
            try
            {
                if (id != value.Id)
                {
                    return NotFound();
                }

                _context.Update(value);
                await _context.SaveChangesAsync();
                return Ok(new { message = "El articulo fue modificado con exito" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Item/ART0001
       
        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            try
            {
                var item =  _context.Items
                    .FirstOrDefault(i => i.Code==code);
                if (item != null)
                {
                    _context.Items.Remove(item);
                    await _context.SaveChangesAsync();
                    return Ok(new { message = "El articulo fue eliminado con exito" });
                }
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
