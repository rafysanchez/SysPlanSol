using Microsoft.EntityFrameworkCore;
using SysPlan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SysPlan.Models
{
    public class ClienteDbContext : DbContext
    {

        public ClienteDbContext(DbContextOptions<ClienteDbContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
