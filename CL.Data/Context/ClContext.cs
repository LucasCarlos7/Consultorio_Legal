using CL.Core.Domain;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Data.Context
{
    public class ClContext : DbContext
    {

        private readonly IConfiguration _configuration;

        public ClContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public virtual DbSet<Cliente> Clientes { get; set; }

        //Configuração adicional do modelo (se necessário)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(ClContext).Assembly
            );
        }

        //Exemplo de configuração adicional, como chave primária ou tabelas nomeadas
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var environment = _configuration["Environment"];
            string connectionString;

            //Verifica o ambiente e escolhe a string da conexão apropriada
            if (environment == "Development")
            {
                connectionString = _configuration.GetConnectionString("DevelopmentConnection");
            }           
            else if (environment == "Production")
            {
                var codCliente = _configuration["CodCliente"];
                connectionString = "";
            }
            else
            {
                throw new InvalidOperationException("Ambiente não configurado corretamente.");
            }

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
