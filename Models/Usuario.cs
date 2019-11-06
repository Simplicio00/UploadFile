using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tst.Models
{
    [Table("USUARIO")]
    public partial class Usuario
    {
        public Usuario()
        {
            Interesse = new HashSet<Interesse>();
        }

        [Key]
        [Column("id_usuario")]
        public int IdUsuario { get; set; }
        [Required]
        [Column("nome_completo")]
        [StringLength(100)]
        public string NomeCompleto { get; set; }
        [Required]
        [Column("nome_usuario")]
        [StringLength(50)]
        public string NomeUsuario { get; set; }
        [Required]
        [Column("email")]
        [StringLength(255)]
        public string Email { get; set; }
        [Required]
        [Column("senha")]
        [StringLength(255)]
        public string Senha { get; set; }
        [Column("imagem_usuario")]
        [StringLength(255)]
        public string ImagemUsuario { get; set; }
        [Column("status_usuario")]
        public bool? StatusUsuario { get; set; }
        [Column("categoria_usuario")]
        public bool? CategoriaUsuario { get; set; }

        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Interesse> Interesse { get; set; }
    }
}
