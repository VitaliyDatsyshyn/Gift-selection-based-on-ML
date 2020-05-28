using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace backend.Helpers
{
    public class PresentsHelper
    {
        public static List<string> Presents { get; private set; }

        public static void ExtractAllPresents(IEnumerable<Person> persons)
        {
            Presents = persons.Select(person => person.Present).Distinct().OrderBy(present => present).Where(present => present != null).ToList();
        }

        public static List<string> GetThreeUniquePresents(List<string> presents)
        {
            var duplicates = presents.GroupBy(present => present).Where(g => g.Count() > 1).Select(g => g.Key).ToList();
            if(duplicates.Count > 2)
            {
                return duplicates.Take(3).ToList();
            }
            else
            {
                duplicates.AddRange(presents.Except(duplicates).OrderBy(present => Guid.NewGuid()).Take(3 - duplicates.Count).ToList());
                return duplicates;
            }
        }
    }
}
