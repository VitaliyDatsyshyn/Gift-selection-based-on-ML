using System.Collections.Generic;

namespace backend.Models
{
    public class Person
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string Relation { get; set; }
        public string Occasion { get; set; }
        public string Interests { get; set; }
        public string PriceLevel { get; set; }
        public string PsycoType { get; set; }
        public string Present { get; set; }

        public IEnumerable<Person> SplitByInterests()
        {
            var interestsArr = Interests.Split(",");
            var persons = new List<Person>();
            foreach(var interest in interestsArr)
            {
                var person = (Person)this.MemberwiseClone();
                person.Interests = interest;
                persons.Add(person);
            }

            return persons;
        }
    }
}
