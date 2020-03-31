using MGonzaga.WebMotors.Anuncios.Domain.Entity.Base;
using MGonzaga.WebMotors.Anuncios.Domain.Interfaces;
using MGonzaga.WebMotors.Anuncios.Domain.Interfaces.Repositories;
using MGonzaga.WebMotors.Anuncios.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MGonzaga.WebMotors.Anuncios.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : EntityBase
    {
        private readonly IDbContext db;
        public BaseRepository(IDbContext db)
        {
            this.db = db;
        }
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public TEntity Adicionar(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
            return db.Set<TEntity>().Add(entity).Entity;

        }

        public TEntity Atualizar(TEntity entity)
        {
            var m = db.Set<TEntity>().Find(entity.Id);
            db.Entry<TEntity>(m).State = EntityState.Detached;
            return db.Set<TEntity>().Update(entity).Entity;
        }

        public TEntity Consultar(int id)
        {
            return db.Set<TEntity>().Where(_ => _.Id == id).FirstOrDefault();
        }

        public List<TEntity> ListarTodos()
        {
            return db.Set<TEntity>().ToList();
        }

        public void Remover(int id)
        {
            var m = db.Set<TEntity>().Find(id);
            db.Set<TEntity>().Remove(m);
            db.SaveChanges();
        }
        public int SaveChanges()
        {
            return db.SaveChanges();
        }
    }
}
