using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjIMago.Models
{
	public class ImagesGos
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int IdImagesGo { get; set; }
		public string Imagego { get; set; }
		[Required(ErrorMessage = "A imagem necessita de uma descrição!")]
		public string Description { get; set; }
	}
}
