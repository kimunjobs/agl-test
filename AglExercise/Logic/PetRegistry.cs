using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract;
using Data;

namespace Logic
{
    public class PetRegistry
    {
        private readonly IPersonRepository repository;

        public PetRegistry(IPersonRepository repository)
        {
            this.repository = repository;
        }

        public PetGenderRegistrations ProduceDailyCatGenderReassignments()
        {
            var result = new PetGenderRegistrations();

            var people = repository.GetAll();

            var groupedPeople = people.GroupBy(person => person.Gender);
            foreach (var grouping in groupedPeople)
            {
                var catsInGroup = grouping.SelectMany(person => person.Pets.Where(pet => pet.Type == PetType.Cat));
                result.Add(grouping.Key, catsInGroup.Select(cat => cat.Name).OrderBy(n => n));
            }

            return result;
        }
    }
}
