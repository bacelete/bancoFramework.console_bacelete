namespace codigo;

using codigo.modelo;
using CpfCnpjLibrary;
class App
{
    static void Main(string[] args)
    {
        Cliente pessoa = salvarDadosCliente();
        Console.WriteLine($"Como posso ajudar? {pessoa.nome}");
        int opcao = 0;
        float valor; 

        while (opcao != 3)
        {
            menu();
            opcao = int.Parse(Console.ReadLine());
            Console.Clear();

            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Digite o valor que deseja depositar: ");
                    valor = float.Parse(Console.ReadLine());
                    depositarSaldo(pessoa, valor);
                    break;
                case 2:
                    Console.WriteLine("Digite o valor que deseja sacar: ");
                    valor = float.Parse(Console.ReadLine());
                    sacarSaldo(pessoa, valor);
                    break;
                case 3:
                    Console.WriteLine("Saindo do sistema...");
                    break;
                default:
                    Console.WriteLine("Digite um valor válido.");
                    break;
            }
        }
    }

    static public void depositarSaldo(Cliente pessoa, float valor)
    {
        if (valor < 0)
        {
            throw new ArgumentException("O valor deve ser positivo!");
        }

        pessoa.saldo += valor;
        pessoa.imprimirSaldo();
    }

    static public void sacarSaldo(Cliente pessoa, float valor)
    {
        float saldo = pessoa.saldo; 
        if (valor > saldo)
        {
            throw new ArgumentException("Saldo infuficiente pra sacar!");
        }

        pessoa.saldo -= valor;
        pessoa.imprimirSaldo();
    }

    static private bool isCpfValid(string cpf)
    {
        return Cpf.Validar(cpf); 
    }

    static private Cliente salvarDadosCliente()
    {
        Console.WriteLine("Seu nome: ");
        string nome = Console.ReadLine();
        Console.WriteLine("Seu identificador: ");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("Seu CPF: ");
        string cpf = Console.ReadLine();
        
        if (!isCpfValid(cpf))
        {
            Console.WriteLine("CPF digitado não é válido.");
        }

        Console.WriteLine("Seu saldo: ");
        float saldo = float.Parse(Console.ReadLine());

        return new Cliente(saldo, nome, id, cpf);
    }

    static void menu()
    {
        Console.WriteLine("1 - Depósito");
        Console.WriteLine("2 - Saque");
        Console.WriteLine("3 - Sair");
        Console.WriteLine("----------");
        Console.WriteLine("Selecione uma opção: ");
    }

}
