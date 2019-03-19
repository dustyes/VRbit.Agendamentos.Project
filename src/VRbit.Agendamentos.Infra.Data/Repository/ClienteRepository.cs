using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRbit.Agendamentos.Domain.Entities;

namespace VRbit.Agendamentos.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public IEnumerable<Cliente> ObterAtivos()
        {
            return Buscar(c => c.Ativo);
        }

        public Cliente ObterPorCpf(string cpf)
        {
            return Buscar(c => c.CPF == cpf).FirstOrDefault(); 
        }

        public Cliente ObterPorEmail(string email)
        {
            return Buscar(c => c.Email == email).FirstOrDefault();
        }

        public override void Remover(Guid id)
        {
            var cliente = SelecionarPorId(id);
            cliente.Ativo = false;
            Atualizar(cliente);
        }

        public override IEnumerable<Cliente> SelecionarTodos()
        {
            var cn = Db.Database.Connection;

            var sql = "SELECT * FROM Clientes";

            return cn.Query<Cliente>(sql);

        }

        public override Cliente SelecionarPorId(Guid id)
        {
            var cn = Db.Database.Connection;

            var sql = @"SELECT * FROM Clientes c " +
                        "LEFT JOIN Enderecos e ON c.ClienteId = e.ClienteId " +
                        "WHERE c.ClienteId = @sid";
            //var data = connection.Query<Post, User, Post>(sql, (post, user) => { post.Owner = user; return post; });
            //var post = data.First();


            var cliente = cn.Query<Cliente, Endereco, Cliente>(sql,
                (c, e) =>
                {
                    e.Cliente = c;
                    c.Enderecos.Add(e);
                    return c;
                }, new {sid = id }, splitOn: "ClienteId, EnderecoId");

            return cliente.FirstOrDefault();

        }
    }
}
