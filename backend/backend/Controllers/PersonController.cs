using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Helpers;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonDbContext _context;

        public PersonController(PersonDbContext context)
        {
            _context = context;
        }

        [HttpGet("relations")]
        public IEnumerable<string> GetRelations()
        {
            return DropdownHelper.GetDistinctValues(_context.Persons.Select(person => person.Relation).ToList());
        }

        [HttpGet("occasions")]
        public IEnumerable<string> GetOccasions()
        {
            return DropdownHelper.GetDistinctValues(_context.Persons.Select(person => person.Occasion).ToList());
        }

        [HttpGet("interests")]
        public IEnumerable<string> GetInterests()
        {
            return DropdownHelper.GetDistinctSplittedValues(_context.Persons.Select(person => person.Interests).ToList());
        }

        [HttpPost]
        public async Task<IActionResult> PostPerson([FromBody] Person person)
        {
            person.ID = _context.Persons.Max(p => p.ID) + 1;
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();

            return Ok(new[] { "Laptop", "Kicks", "Play Station"});
        }
    }
}