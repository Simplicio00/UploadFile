using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tst.Models
{
    [Table("EQUIPAMENTO")]
    public partial class Equipamento
    {
        public Equipamento()
        {
            Classificado = new HashSet<Classificado>();
        }

        [Key]
        [Column("id_equipamento")]
        public int IdEquipamento { get; set; }
        [Required]
        [Column("nome_equipamento")]
        [StringLength(50)]
        public string NomeEquipamento { get; set; }
        [Required]
        [Column("marca")]
        [StringLength(50)]
        public string Marca { get; set; }
        [Column("modelo")]
        [StringLength(50)]
        public string Modelo { get; set; }
        [Column("sistema_operacional")]
        [StringLength(50)]
        public string SistemaOperacional { get; set; }
        [Column("polegada")]
        [StringLength(50)]
        public string Polegada { get; set; }
        [Column("processador")]
        [StringLength(50)]
        public string Processador { get; set; }
        [Column("memoria_ram")]
        [StringLength(50)]
        public string MemoriaRam { get; set; }
        [Column("ssd")]
        [StringLength(50)]
        public string Ssd { get; set; }
        [Column("hd")]
        [StringLength(50)]
        public string Hd { get; set; }
        [Column("placa_de_video")]
        [StringLength(50)]
        public string PlacaDeVideo { get; set; }
        [Column("alimentacao")]
        [StringLength(50)]
        public string Alimentacao { get; set; }
        [Column("peso")]
        [StringLength(50)]
        public string Peso { get; set; }
        [Column("dimensoes")]
        [StringLength(50)]
        public string Dimensoes { get; set; }
        [Column("status_equipamento")]
        public bool? StatusEquipamento { get; set; }
        [Column("id_categoria")]
        public int? IdCategoria { get; set; }

        [ForeignKey(nameof(IdCategoria))]
        [InverseProperty(nameof(Categoria.Equipamento))]
        public virtual Categoria IdCategoriaNavigation { get; set; }
        [InverseProperty("IdEquipamentoNavigation")]
        public virtual ICollection<Classificado> Classificado { get; set; }
    }
}
