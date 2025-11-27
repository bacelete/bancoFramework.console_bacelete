namespace codigo.modelo;

public class Pessoa
{
    public int id { get; set; }
    public string nome { get; set ;}
    public string cpf { get; set; }

    public Pessoa() { }
    public Pessoa(string nome, int id, string cpf)
    {
        this.nome = nome;
        this.id = id;
        this.cpf = cpf;
    }
}
