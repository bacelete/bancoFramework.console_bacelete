namespace codigo.Interfaces;

using codigo.Model;

public interface IClienteRepository
{
    void Create(Cliente cliente);
    Cliente GetById(int id);
    void Update(Cliente cliente);
    void Delete(int id);    
}