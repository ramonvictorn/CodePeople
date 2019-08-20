namespace CodePeople.Repository
{
    public interface IPersonRepository
    {
        void GetByName(string name);
        void GetByCpf(int Cpf);
    }
}