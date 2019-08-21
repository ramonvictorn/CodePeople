using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CodePeople.Model;
using CodePeople.Repository;
namespace CodePeople.Model{  
    [Route("api/people")]
    public class PersonController : Controller
    {
        private readonly PersonContext _context;
        IPersonRepository _personRepository;
        // PersonRepository PersonRepository = new PersonRepository();
        public PersonController(PersonContext context, IPersonRepository PersonRepository)
        {
            _context = context;
            _personRepository = PersonRepository;
        }

        [HttpGet]
        public List<Person> GetAllUsers()
        {
            return _personRepository.GetAllPeople();
        }
        // [HttpGet]
        // public List<Person> GetById()
        // {
        //     return _personRepository.GetAllPeople();
        // }
        
        // [HttpGet]
        // public List<Person> get(
        //     [FromQuery]string offset,
        //     [FromQuery]string orderBy,
        //     Person personToSearch
        // )
        // {   
        //     int _offset = offset == null ? 0 : int.Parse(offset);
        //     string _orderBy = orderBy == null ? "id" : orderBy;
        //     var peopleWithFilters = from p in _context.People select p;

        //         peopleWithFilters = peopleWithFilters.Where(p => 
        //             (personToSearch.Nome  == null || p.Nome == personToSearch.Nome) &&
        //             (personToSearch.Email  == null || p.Email == personToSearch.Email) &&
        //             (personToSearch.Cpf  == null || p.Cpf == personToSearch.Cpf) &&
        //             (personToSearch.Telefone  == null || p.Telefone == personToSearch.Telefone)
                    
        //         ).Skip(_offset).Take(10);

        //         switch (_orderBy)
        //         {
        //             case "cpf":
        //                 peopleWithFilters = peopleWithFilters.OrderBy(p => p.Cpf);
        //                 break;
        //             case "nome":
        //                 peopleWithFilters = peopleWithFilters.OrderBy(p => p.Nome);
        //                 break;
        //             case "telefone":
        //                 peopleWithFilters = peopleWithFilters.OrderBy(p => p.Telefone);
        //                 break;
        //             default:
        //                 peopleWithFilters = peopleWithFilters.OrderBy(p => p.Id);
        //                 break;
        //         }
        //     return peopleWithFilters.ToList();
        // }

        [HttpPost]
        public IActionResult Post([FromBody] Person values)
        {
            if(values == null)
            {
                return BadRequest();
            }
            if(values.Email == null)
            {
                return BadRequest();
            }
            if(values.Senha == null)
            {
                return BadRequest();
            }
            _context.People.Add(values);
            _context.SaveChanges();
            return StatusCode(201, values);
        }

        [HttpPut("{id}")]
        public IActionResult EditPerson(string id, [FromBody] Person person)
        {
            int _id = int.Parse(id); //failed to try?
            person.Id = _id;
            var existingPerson = _context.People.Where(s => s.Id == person.Id).FirstOrDefault<Person>();

            if (existingPerson != null)
            {
                existingPerson.Nome = person.Nome != null ? person.Nome : existingPerson.Nome;
                existingPerson.Cpf = person.Cpf != null ? person.Cpf : existingPerson.Cpf;
                existingPerson.Telefone = person.Telefone != null ? person.Telefone : existingPerson.Telefone;
                existingPerson.Email = person.Email != null ? person.Email : existingPerson.Email;
                existingPerson.Senha = person.Senha != null ? person.Senha : existingPerson.Senha;
                _context.SaveChanges();
            }
            return NoContent();
        }
    }
}
