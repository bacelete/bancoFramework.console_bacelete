namespace codigo.modelo; 
public class Cliente : Pessoa
{
    public float saldo {get; set;}

    public Cliente () {}
    public Cliente(float saldo, string nome, int id, string cpf) : base(nome, id, cpf)
    {
        this.saldo = saldo;  
    }

    public void imprimirSaldo()
    {
        Console.WriteLine($"Seu saldo é: {saldo}"); 
    }
}