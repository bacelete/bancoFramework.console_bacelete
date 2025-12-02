namespace codigo;

using codigo.Model;
using CpfCnpjLibrary;
using codigo.Data;
using codigo.Interfaces;
using codigo.Repository;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

class Program
{
    static void Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                services.AddDbContext<ApplicationDbContext>();
                services.AddScoped<IClienteRepository, ClienteRepository>();
                services.AddTransient<App>();
            })
            .Build();

        var app = host.Services.GetRequiredService<App>();
        app.Run();
    }
}

class App
{
    public static IClienteRepository _clienteRepository;

    public App(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public void Run()
    {
        Cliente pessoa = LerDadosDoCliente();
        Console.WriteLine($"Como posso ajudar? {pessoa.nome}");
        int opcao = 0;
        float valor; 

        while (opcao != 3)
        {
            Menu();
            opcao = int.Parse(Console.ReadLine());
            Console.Clear();

            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Digite o valor que deseja depositar: ");
                    valor = float.Parse(Console.ReadLine());
                    DepositarSaldo(pessoa, valor);
                    break;
                case 2:
                    Console.WriteLine("Digite o valor que deseja sacar: ");
                    valor = float.Parse(Console.ReadLine());
                    SacarSaldo(pessoa, valor);
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

    static public void DepositarSaldo(Cliente pessoa, float valor)
    {
        if (valor < 0)
        {
            throw new ArgumentException("O valor deve ser positivo!");
        }

        pessoa.saldo += valor;
        pessoa.ImprimirSaldo();
    }


    static public void SacarSaldo(Cliente pessoa, float valor)
    {
        float saldo = pessoa.saldo; 
        if (valor > saldo)
        {
            throw new ArgumentException("Saldo infuficiente pra sacar!");
        }

        pessoa.saldo -= valor;
        pessoa.ImprimirSaldo();

        _clienteRepository.Update(pessoa);
    }

    static private bool IsCpfValid(string cpf)
    {
        return Cpf.Validar(cpf); 
    }

    static private Cliente LerDadosDoCliente()
    {
        Console.WriteLine("Seu nome: ");
        string nome = Console.ReadLine();
        Console.WriteLine("Seu identificador: ");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("Seu CPF: ");
        string cpf = Console.ReadLine();

        if (!IsCpfValid(cpf))
        {
            Console.WriteLine("CPF digitado não é válido.");
        }

        Console.WriteLine("Seu saldo: ");
        float saldo = float.Parse(Console.ReadLine());

        return SalvarDadosCliente(saldo, nome, id, cpf);
    }

    static private Cliente SalvarDadosCliente(float saldo, string nome, int id, string cpf)
    {
        
        Cliente cliente = new Cliente(saldo, nome, id, cpf);
        _clienteRepository.Create(cliente);
        Console.WriteLine("Cliente salvo com sucesso!"); 

        return cliente; 
    }

    static void Menu()
    {
        Console.WriteLine("1 - Depósito");
        Console.WriteLine("2 - Saque");
        Console.WriteLine("3 - Sair");
        Console.WriteLine("----------");
        Console.WriteLine("Selecione uma opção: ");
    }

}
