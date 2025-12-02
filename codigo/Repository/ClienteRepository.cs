namespace codigo.Repository;
using codigo.Data;
using codigo.Interfaces;
using codigo.Model;

public class ClienteRepository : IClienteRepository
{
    private readonly ApplicationDbContext _context;

    public ClienteRepository(ApplicationDbContext context)
    {
        this._context = context;
    }

    public void Create(Cliente cliente)
    {
        _context.Add(cliente);
        _context.SaveChanges();
    }

    public Cliente GetById(int id)
    {
        return _context.Cliente.Find(id);
    }

    public void Update(Cliente novo)
    {
        _context.Update(novo);
        _context.SaveChanges(); 

    }

    public void Delete(int id)
    {
        Cliente cliente = GetById(id);

        if (cliente == null)
        {
            throw new Exception("Cliente não encontrado.");
        }

        _context.Remove(cliente);
        _context.SaveChanges();
    }

}