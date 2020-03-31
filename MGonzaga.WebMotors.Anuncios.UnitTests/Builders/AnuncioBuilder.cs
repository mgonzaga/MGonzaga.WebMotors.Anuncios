using MGonzaga.WebMotors.Anuncios.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGonzaga.WebMotors.Anuncios.UnitTests.Builders
{
    public class AnuncioBuilder
    {
        public Anuncio Build()
        {
        
            return new Anuncio()
            {
                Marca = "Fiat",
                Modelo = "Palio",
                Versao = "Elx 1.0 MPI",
                Ano = 2003,
                Quilometragem = 10000,
                Observacao = "Possui Detalhes de uso na Pintura"
            };
        }
    }
}
