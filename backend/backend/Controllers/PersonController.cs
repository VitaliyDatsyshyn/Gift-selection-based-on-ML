using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Helpers;
using backend.ML;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonDbContext _context;
        private readonly ModelScorer _modelScorer;

        public PersonController(PersonDbContext context)
        {
            _context = context;
            PresentsHelper.ExtractAllPresents(_context.Persons);
            _modelScorer = new ModelScorer("GeneticModel.zip");
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
        public IActionResult PostPerson([FromBody] Person person)
        {
            var splittedPersons = person.SplitByInterests();
            var predictedPresents = new List<string>();
            foreach (var splittedPerson in splittedPersons)
            {
                predictedPresents.AddRange(_modelScorer.PredictPresents(splittedPerson));
            }

            return Ok(PresentsHelper.GetThreeUniquePresents(predictedPresents));
        }

        [HttpPost()]
        [Route("AddPerson")]
        public async Task<IActionResult> AddPersonToDB([FromBody] Person personWithPresent)
        {
            var splittedPersons = personWithPresent.SplitByInterests();
            _context.Persons.AddRange(splittedPersons);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}