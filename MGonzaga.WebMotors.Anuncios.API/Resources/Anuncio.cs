using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MGonzaga.WebMotors.Anuncios.API.Resources
{
    public class Anuncio
    {
        public String Marca { get; set; }
        public String Modelo { get; set; }
        public String Versao { get; set; }
        public int Ano { get; set; }
        public int Quilometragem { get; set; }
        public String Observacao { get; set; }

        public MGonzaga.WebMotors.Anuncios.Domain.Entity.Anuncio ToEntity()
        {
            return new MGonzaga.WebMotors.Anuncios.Domain.Entity.Anuncio()
            {
                Marca = Marca,
                Modelo = Modelo,
                Versao = Versao,
                Ano = Ano,
                Quilometragem = Quilometragem,
                Observacao = Observacao
            };

        }
        
        public Anuncio FromEntity(MGonzaga.WebMotors.Anuncios.Domain.Entity.Anuncio entity)
        {

            Marca = entity.Marca;
            Modelo = entity.Modelo;
            Versao = entity.Versao;
            Ano = entity.Ano;
            Quilometragem = entity.Quilometragem;
            Observacao = entity.Observacao;

            return this;

        }
    }
}
