using SysPlan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SysPlan.Data
{
   public interface  IClienteData
    {
        List<Cliente> GetClientes();

        Cliente GetCliente(Guid id);

        Cliente AddCliente(Cliente cliente);

        Cliente EditCliente(Cliente cliente);

        void DeleteCliente(Cliente cliente);

    }
}
