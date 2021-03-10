using SysPlan.Data;
using SysPlan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SysPlan.Bussiness
{
    public class ClienteService : IClienteData
    {
        private ClienteDbContext _dbContext;

        public ClienteService(ClienteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Cliente AddCliente(Cliente cliente)
        {
            cliente.Id = Guid.NewGuid();
            _dbContext.Clientes.Add(cliente);
            return cliente;
        }

        public void DeleteCliente(Cliente cliente)
        {
            _dbContext.Clientes.Remove(cliente);
            _dbContext.SaveChanges();
        }

        public Cliente EditCliente(Cliente cliente)
        {
            var existingCliente = GetCliente(cliente.Id);

            existingCliente.Nome = cliente.Nome;
            existingCliente.Idade = cliente.Idade;
            _dbContext.Clientes.Update(existingCliente);
            _dbContext.SaveChanges();

            return existingCliente;
        }

        public Cliente GetCliente(Guid id)
        {
            return _dbContext.Clientes.SingleOrDefault(x => x.Id == id);
        }

        public List<Cliente> GetClientes()
        {
            return _dbContext.Clientes.ToList();
        }
    }
}
