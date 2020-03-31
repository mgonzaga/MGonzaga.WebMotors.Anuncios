using MGonzaga.WebMotors.Anuncios.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGonzaga.WebMotors.Anuncios.UnitTests
{
    public class MockContext : IDbContext
    {
        public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            return null;
        }

        public int SaveChanges()
        {
            return 1;
        }

        public DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return null;
        }
    }
}
