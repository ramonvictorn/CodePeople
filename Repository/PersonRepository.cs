using CodePeople.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
namespace CodePeople.Repository 
{
    public class PersonRepository : IPersonRepository
    {   
        PersonContext _context;

        public PersonRepository(PersonContext context)
        {
            _context = context;
        }
        public List<Person> GetAllPeople()
        {
            var peopleWithFilters = from p in _context.People select p;
            return peopleWithFilters.ToList();
        }
        public void GetByName(string name)
        {

        }

        public void GetByCpf(int Cpf)
        {

        }
    }

}