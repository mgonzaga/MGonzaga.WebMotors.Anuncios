using MGonzaga.WebMotors.Anuncios.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGonzaga.WebMotors.Anuncios.Infrastructure.Context
{
    public class TesteWebMotorsContext : DbContext, IDbContext
    {
        public TesteWebMotorsContext()
        {
        }
        public TesteWebMotorsContext(DbContextOptions<TesteWebMotorsContext> options) : base(options)
        {
        }
        public DbSet<Anuncio> Anuncios { get; set; }

    }
}
