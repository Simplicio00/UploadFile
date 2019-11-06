using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tst.Models
{
    [Table("INTERESSE")]
    public partial class Interesse
    {
        [Key]
        [Column("id_interesse")]
        public int IdInteresse { get; set; }
        [Column("status_interesse")]
        public bool? StatusInteresse { get; set; }
        [Column("comprador")]
        public bool? Comprador { get; set; }
        [Column("data_compra", TypeName = "datetime")]
        public DateTime? DataCompra { get; set; }
        [Column("data_interesse", TypeName = "datetime")]
        public DateTime? DataInteresse { get; set; }
        [Column("id_classificado")]
        public int? IdClassificado { get; set; }
        [Column("id_usuario")]
        public int? IdUsuario { get; set; }

        [ForeignKey(nameof(IdClassificado))]
        [InverseProperty(nameof(Classificado.Interesse))]
        public virtual Classificado IdClassificadoNavigation { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(Usuario.Interesse))]
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
