using CL.Core.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Manager.Interface
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetClienteAsync();
        Task<Cliente> GetClienteAsync(int id);
    }
}
