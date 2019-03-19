using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRbit.Agendamentos.Domain.Entities;
using VRbit.Agendamentos.Domain.Interfaces.Repository;

namespace VRbit.Agendamentos.Infra.Data.Repository
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Cliente ObterPorCpf(string cpf);
        Cliente ObterPorEmail(string email);
        IEnumerable<Cliente> ObterAtivos();
    }
}
