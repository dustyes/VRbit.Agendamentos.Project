using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VRbit.Agendamentos.Domain.Interfaces.Repository;
using VRbit.Agendamentos.Infra.Data.Context;

namespace VRbit.Agendamentos.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected AgendamentosContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository()
        {
            Db = new AgendamentosContext();
            DbSet = Db.Set<TEntity>();
        }

        public virtual TEntity Adicionar(TEntity obj)
        {
            var ObjAdd = DbSet.Add(obj);
            SaveChanges();
            return ObjAdd;
        }

        public virtual TEntity Atualizar(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
            SaveChanges();

            return obj;
        }

        public virtual IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual void Remover(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
            SaveChanges();
        }

        public virtual int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public virtual TEntity SelecionarPorId(Guid id)
        {
            return DbSet.Find(id);
        }

        //paginação
        //public IEnumerable<TEntity> SelecionarTodos(int t, int s)
        //{
        //    return DbSet.Skip(s).Take(t).ToList();
        //}

        public virtual IEnumerable<TEntity> SelecionarTodos()
        {
            return DbSet.ToList();
        }
    }
}
