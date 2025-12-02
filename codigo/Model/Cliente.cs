using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace codigo.Model;

public class Cliente : Pessoa
{
    public float saldo {get; set;}

    public Cliente () {}
    public Cliente(float saldo, string nome, int id, string cpf) : base(nome, id, cpf)
    {
        this.saldo = saldo;  
    }

    public void ImprimirSaldo()
    {
        Console.WriteLine($"Seu saldo é: {saldo}"); 
    }
}