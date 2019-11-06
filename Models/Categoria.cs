using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tst.Models
{
    [Table("CATEGORIA")]
    public partial class Categoria
    {
        public Categoria()
        {
            Equipamento = new HashSet<Equipamento>();
        }

        [Key]
        [Column("id_categoria")]
        public int IdCategoria { get; set; }
        [Required]
        [Column("nome_categoria")]
        [StringLength(50)]
        public string NomeCategoria { get; set; }
        [Column("status_categoria")]
        public bool? StatusCategoria { get; set; }

        [InverseProperty("IdCategoriaNavigation")]
        public virtual ICollection<Equipamento> Equipamento { get; set; }
    }
}
