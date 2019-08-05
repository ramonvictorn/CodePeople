using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CodePeople.Model{

public class Person{
    public int Id { get; set; }
    public string Nome {get;set;}
    [Required]
    public int Cpf {get;set;}
    public int Telefone {get;set;}
    [Required]
    public string Email {get;set;}
    public string Senha {get;set;}
}
}