using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CodePeople.Model;
namespace CodePeople.Model{  
    [Route("api/people")]
    public class PersonController : Controller
    {
        private readonly PersonContext _context;
        public PersonController(PersonContext context)
        {
            _context = context;
        }
        [HttpGet]
        public List<Person> get(
            [FromQuery]string filterName,
            [FromQuery]string filterEmail,
            [FromQuery]string filterCpf, 
            [FromQuery]string filterTelefone,
            [FromQuery]string offset,
            [FromQuery]string orderBy
            )
        {   

            // int _filterCpf = filterCpf == null ? 0 : int.Parse(filterCpf);
            // int _filterTelefone = filterTelefone == null ? 0 : int.Parse(filterTelefone);
            int _offset = offset == null ? 0 : int.Parse(offset);
            string _orderBy = orderBy == null ? "id" : orderBy;
            //List<Person> personWithOrder;
            List<Person> personWithFilters = _context.People
                .Where(p => 
                    (filterName  == null || p.Nome == filterName) &&
                    (filterEmail  == null || p.Email == filterEmail) &&
                    (filterCpf  == null || p.Cpf == filterCpf) &&
                    (filterTelefone  == null || p.Telefone == filterTelefone)
                    
                ).Skip(_offset).ToList();
                
                var teste = from p in _context.People select p;

                teste = teste.Where(p => 
                    (filterName  == null || p.Nome == filterName) &&
                    (filterEmail  == null || p.Email == filterEmail) &&
                    (filterCpf  == null || p.Cpf == filterCpf) &&
                    (filterTelefone  == null || p.Telefone == filterTelefone)
                    
                ).Skip(_offset);

                switch (_orderBy)
                {
                    case "cpf":
                        teste = teste.OrderBy(p => p.Cpf);
                        break;
                    case "nome":
                        teste = teste.OrderBy(p => p.Nome);
                        break;
                    case "telefone":
                        teste = teste.OrderBy(p => p.Telefone);
                        break;
                    default:
                        teste = teste.OrderBy(p => p.Id);
                        break;
                }

            // return personWithFilters;
            return teste.ToList();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person value)
        {
            if(value == null)
            {
                return BadRequest();
            }
            if(value.Email == null)
            {
                return BadRequest();
            }
            if(value.Senha == null)
            {
                return BadRequest();
            }
            _context.People.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }

        [HttpPut("{id}")]
        public IActionResult EditPerson(string id, [FromBody] Person person)
        {
            int _id = int.Parse(id);
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
