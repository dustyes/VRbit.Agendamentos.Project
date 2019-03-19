using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace VRbit.Agendamentos.Domain.Interfaces.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Adicionar(TEntity obj);
        TEntity SelecionarPorId(Guid id);
        IEnumerable<TEntity> SelecionarTodos();
        TEntity Atualizar(TEntity obj);
        void Remover(Guid id);

        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);

        int SaveChanges();

    }
}
