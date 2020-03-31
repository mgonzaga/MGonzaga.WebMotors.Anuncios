using MGonzaga.WebMotors.Anuncios.Domain.Entity;
using MGonzaga.WebMotors.Anuncios.Domain.Interfaces.Repositories;
using MGonzaga.WebMotors.Anuncios.Infrastructure.Exceptions;
using MGonzaga.WebMotors.Anuncios.Infrastructure.Repositories;
using MGonzaga.WebMotors.Anuncios.UnitTests.Builders;
using Xunit;

namespace MGonzaga.WebMotors.Anuncios.UnitTests.AnuncioTests
{
    public class AdicionarAnuncioTest
    {
        private readonly IAnuncioRepository repository;
        public AdicionarAnuncioTest()
        {
            repository = new AnuncioRepository(new MockContext());
        }
        #region Campo Marca
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Marca_Empty_GeraErroValidacao(string marca)
        {
            try
            {
                var anuncio = new AnuncioBuilder().Build();
                anuncio.Marca = marca;
                var result = repository.Adicionar(anuncio);
                Assert.True(true);
            }
            catch (ValidationException ve)
            {
                Assert.Equal(ve.Message, Anuncio.MarcaObrigatoria);
            }
        }
        [Theory]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaAAAA")]
        public void Marca_MaiorQueLimite_GeraErroValidacao(string marca)
        {
            try
            {
                var anuncio = new AnuncioBuilder().Build();
                anuncio.Marca = marca;
                var result = repository.Adicionar(anuncio);
                Assert.True(true);
            }
            catch (ValidationException ve)
            {
                Assert.Equal(ve.Message, Anuncio.MarcaMaiorQueLimite);
            }
        }
        #endregion
        
        #region Campo Modelo
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Modelo_Empty_GeraErroValidacao(string valor)
        {
            try
            {
                var anuncio = new AnuncioBuilder().Build();
                anuncio.Modelo = valor;
                var result = repository.Adicionar(anuncio);
                Assert.True(true);
            }
            catch (ValidationException ve)
            {
                Assert.Equal(ve.Message, Anuncio.ModeloObrigatoria);
            }
        }
        [Theory]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaAAAA")]
        public void Modelo_MaiorQueLimite_GeraErroValidacao(string valor)
        {
            try
            {
                var anuncio = new AnuncioBuilder().Build();
                anuncio.Modelo = valor;
                var result = repository.Adicionar(anuncio);
                Assert.True(true);
            }
            catch (ValidationException ve)
            {
                Assert.Equal(ve.Message, Anuncio.ModeloMaiorQueLimite);
            }
        }
        #endregion
        
        #region Campo Versao
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Versao_Empty_GeraErroValidacao(string valor)
        {
            try
            {
                var anuncio = new AnuncioBuilder().Build();
                anuncio.Versao = valor;
                var result = repository.Adicionar(anuncio);
                Assert.True(true);
            }
            catch (ValidationException ve)
            {
                Assert.Equal(ve.Message, Anuncio.VersaoObrigatoria);
            }
        }
        [Theory]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaAAAA")]
        public void Versao_MaiorQueLimite_GeraErroValidacao(string valor)
        {
            try
            {
                var anuncio = new AnuncioBuilder().Build();
                anuncio.Versao = valor;
                var result = repository.Adicionar(anuncio);
                Assert.True(true);
            }
            catch (ValidationException ve)
            {
                Assert.Equal(ve.Message, Anuncio.VersaoMaiorQueLimite);
            }
        }
        #endregion

        #region Campo Ano
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void Ano_MenorOuIgualZero_GeraErroValidacao(int valor)
        {
            try
            {
                var anuncio = new AnuncioBuilder().Build();
                anuncio.Ano = valor;
                var result = repository.Adicionar(anuncio);
                Assert.True(true);
            }
            catch (ValidationException ve)
            {
                Assert.Equal(ve.Message, Anuncio.AnoMaiorQueZero);
            }
        }
        #endregion

        #region Campo Quilometragem
        [Theory]
        [InlineData(-1)]
        public void Quilometragem_MenoQueZero_GeraErroValidacao(int valor)
        {
            try
            {
                var anuncio = new AnuncioBuilder().Build();
                anuncio.Quilometragem = valor;
                var result = repository.Adicionar(anuncio);
                Assert.True(true);
            }
            catch (ValidationException ve)
            {
                Assert.Equal(ve.Message, Anuncio.QuilometrageMaiorIgualQueZero);
            }
        }
        #endregion
    }
}