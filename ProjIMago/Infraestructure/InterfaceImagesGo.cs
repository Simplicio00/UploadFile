using Microsoft.AspNetCore.Http;
using ProjIMago.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjIMago.Infraestructure
{
	public interface InterfaceImagesGo
	{
		public Task<List<ImagesGos>>  GetAll();

		public Task <ImagesGos> GetById(int id);

		public Task<ImagesGos> Post(ImagesGos obj);

		public string Imago(IFormFile file, string savingFolder);

	}
}
