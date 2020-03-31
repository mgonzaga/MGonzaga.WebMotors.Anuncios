using MGonzaga.WebMotors.Anuncios.Domain.Entity;
using MGonzaga.WebMotors.Anuncios.Domain.Interfaces.Repositories;
using MGonzaga.WebMotors.Anuncios.Infrastructure.Context;
using MGonzaga.WebMotors.Anuncios.Infrastructure.Exceptions;

namespace MGonzaga.WebMotors.Anuncios.Infrastructure.Repositories
{
    public class AnuncioRepository : BaseRepository<Anuncio>, IAnuncioRepository
    {
        public AnuncioRepository(IDbContext db) : base(db)
        {
        }
        public new virtual Anuncio Adicionar(Anuncio entidade)
        {
            ValidarEntidade(entidade);
            base.Adicionar(entidade);
            base.SaveChanges();
            return entidade;
        }
        public new virtual Anuncio Atualizar(Anuncio entidade)
        {
            ValidarEntidade(entidade);
            base.Atualizar(entidade);
            base.SaveChanges();
            return entidade;
        }
        private void ValidarEntidade(Anuncio entidade)
        {
            if (string.IsNullOrEmpty(entidade.Marca)) throw new ValidationException(Anuncio.MarcaObrigatoria);
            if (entidade.Marca.Length > 45) throw new ValidationException(Anuncio.MarcaMaiorQueLimite);

            if (string.IsNullOrEmpty(entidade.Modelo)) throw new ValidationException(Anuncio.ModeloObrigatoria);
            if (entidade.Modelo.Length > 45) throw new ValidationException(Anuncio.ModeloMaiorQueLimite);

            if (string.IsNullOrEmpty(entidade.Versao)) throw new ValidationException(Anuncio.VersaoObrigatoria);
            if (entidade.Versao.Length > 45) throw new ValidationException(Anuncio.VersaoMaiorQueLimite);

            if (entidade.Ano <= 0) throw new ValidationException(Anuncio.AnoMaiorQueZero);

            if (entidade.Quilometragem < 0) throw new ValidationException(Anuncio.QuilometrageMaiorIgualQueZero);
        }
    }
}
