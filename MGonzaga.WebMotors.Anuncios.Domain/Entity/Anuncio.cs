using MGonzaga.WebMotors.Anuncios.Domain.Entity.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MGonzaga.WebMotors.Anuncios.Domain.Entity
{
    [Table("tb_AnuncioWebmotors")]
    public class Anuncio : EntityBase
    {
        public static readonly string MarcaMaiorQueLimite = "A Marca deve conter no máximo 45 caracteres";
        public static readonly string MarcaObrigatoria = "A Marca deve conter no máximo 45 caracteres";
        
        public static readonly string ModeloMaiorQueLimite = "O Modelo deve conter no máximo 45 caracteres";
        public static readonly string ModeloObrigatoria = "O Modelo deve conter no máximo 45 caracteres";

        public static readonly string VersaoMaiorQueLimite = "A versão deve conter no máximo 45 caracteres";
        public static readonly string VersaoObrigatoria = "A versão deve conter no máximo 45 caracteres";

        public static readonly string AnoMaiorQueZero = "O Ano Deve ser maior que Zero";

        public static readonly string QuilometrageMaiorIgualQueZero = "A Quilometragem Deve ser maiorou igual a Zero";

        [MaxLength(45)]
        public String Marca { get; set; }
        [MaxLength(45)]
        public String Modelo { get; set; }
        [MaxLength(45)]
        public String Versao { get; set; }
        public int Ano { get; set; }
        public int Quilometragem { get; set; }
        public String Observacao { get; set; }

    }
}
