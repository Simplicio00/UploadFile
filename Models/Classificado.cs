using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tst.Models
{
    [Table("CLASSIFICADO")]
    public partial class Classificado
    {
        public Classificado()
        {
            Interesse = new HashSet<Interesse>();
        }

        [Key]
        [Column("id_classificado")]
        public int IdClassificado { get; set; }
        [Column("codigo_classificado")]
        public int? CodigoClassificado { get; set; }
        [Column("preco", TypeName = "money")]
        public decimal Preco { get; set; }
        [Required]
        [Column("numero_de_serie")]
        [StringLength(60)]
        public string NumeroDeSerie { get; set; }
        [Required]
        [Column("avaliacao", TypeName = "text")]
        public string Avaliacao { get; set; }
        [Column("fim_de_vida_util", TypeName = "date")]
        public DateTime FimDeVidaUtil { get; set; }
        [Column("data_fabricacao", TypeName = "date")]
        public DateTime DataFabricacao { get; set; }
        [Column("softwares_inclusos", TypeName = "text")]
        public string SoftwaresInclusos { get; set; }
        [Column("status_classificado")]
        public bool? StatusClassificado { get; set; }
        [Column("id_imagem_classificado")]
        public int? IdImagemClassificado { get; set; }
        [Column("id_equipamento")]
        public int? IdEquipamento { get; set; }

        [ForeignKey(nameof(IdEquipamento))]
        [InverseProperty(nameof(Equipamento.Classificado))]
        public virtual Equipamento IdEquipamentoNavigation { get; set; }
        [ForeignKey(nameof(IdImagemClassificado))]
        [InverseProperty(nameof(Imagemclassificado.Classificado))]
        public virtual Imagemclassificado IdImagemClassificadoNavigation { get; set; }
        [InverseProperty("IdClassificadoNavigation")]
        public virtual ICollection<Interesse> Interesse { get; set; }
    }
}
