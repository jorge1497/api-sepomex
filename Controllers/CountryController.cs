using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_sepomex.Models;
using ConciliatorServices.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_sepomex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("SepomexPolicy")]
    [ExceptionFilter]
    [Authorize("Bearer")]
    public class CountryController : ControllerBase
    {
        private readonly IntranetContext _context;

        public CountryController(IntranetContext context)
        {
            _context = context;
        }
        // GET api/country
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> Get()
        {
            return await _context.Country.ToListAsync();
        }

        [HttpGet("{id}")]// GET api/country/5
        public async Task<ActionResult<Country>> Get(int id)
        {
            var country = await _context.Country.FindAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            return country;
        }

        // POST api/country
        [HttpPost]
        public async Task<ActionResult<Country>> Post([FromBody]Country country)
        {
            int? max = _context.Country.Select(c => c.CountryID).Max();
            _context.Country.Add(new Country
            {
                CountryID = max != null ? Convert.ToInt32(max) + 1 : 1,
                Code = country.Code,
                Currency = country.Currency,
                CurrencyCode = country.CurrencyCode,
                UserID = 1,
                Name = country.Name,
                Active = country.Active,
                LastChange = DateTime.Now,
            });
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = country.CountryID }, country);
        }

        // PUT api/country/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Country>> Put(int id, [FromBody]Country country)
        {
            if (id != country.CountryID)
            {
                return BadRequest();
            }

            _context.Entry(country).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = country.CountryID }, country);
        }

        // DELETE api/country/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var country = await _context.Country.FindAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            _context.Country.Remove(country);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        // POST api/country
        [HttpPost("masivedelete")]
        [AllowAnonymous]
        public async Task<IActionResult> MasiveDelete([FromBody]int[] ids)
        {
            foreach (int id in ids)
            {
                var country = await _context.Country.FindAsync(id);
                if (country == null)
                {
                    return NotFound();
                }
                _context.Country.Remove(country);
            }
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}