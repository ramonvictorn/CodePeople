using CodePeople.Model;
using System.Collections.Generic;
namespace CodePeople.Repository
{
    public interface IPersonRepository
    {

        List<Person> GetAllPeople();
        void GetByName(string name);
        void GetByCpf(int Cpf);
    }
}