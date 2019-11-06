using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tst.Models
{
    [Table("IMAGEMCLASSIFICADO")]
    public partial class Imagemclassificado
    {
        public Imagemclassificado()
        {
            Classificado = new HashSet<Classificado>();
        }

        [Key]
        [Column("id_imagem_classificado")]
        public int IdImagemClassificado { get; set; }
        [Required]
        [Column("imagem_principal")]
        [StringLength(255)]
        public string ImagemPrincipal { get; set; }
        [Column("imagem_sec1")]
        [StringLength(255)]
        public string ImagemSec1 { get; set; }
        [Column("imagem_sec2")]
        [StringLength(255)]
        public string ImagemSec2 { get; set; }
        [Column("imagem_sec3")]
        [StringLength(255)]
        public string ImagemSec3 { get; set; }

        [InverseProperty("IdImagemClassificadoNavigation")]
        public virtual ICollection<Classificado> Classificado { get; set; }
    }
}
