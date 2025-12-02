namespace codigo.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Pessoa")]
public class Pessoa
{
    [Key]
    public int id { get; set; }

    [Required(ErrorMessage = "Digite um nome válido.")]
    public string nome { get; set ;}

    [Required(ErrorMessage = "Digite um CPF válido.")]
    public string cpf { get; set; }

    public Pessoa() { }
    public Pessoa(string nome, int id, string cpf)
    {
        this.nome = nome;
        this.id = id;
        this.cpf = cpf;
    }
}
