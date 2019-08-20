using CodePeople.Model;
using Microsoft.EntityFrameworkCore;
namespace CodePeople.Repository 
{
    public class PersonRepository : IPersonRepository
    {   
        PersonContext _context;
        public PersonRepository(PersonContext context)
        {
            _context = context;
        }
        public void GetByName(string name)
        {

        }

        public void GetByCpf(int Cpf)
        {

        }
    }

}