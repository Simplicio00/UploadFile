using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ProjIMago.Data;
using ProjIMago.Infraestructure;
using ProjIMago.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ProjIMago.Services
{
	public class ImagesGoRepository : InterfaceImagesGo
	{
		private IMagoContext _context;
		public ImagesGoRepository(IMagoContext context)
		{
			_context = context;
		}

		public async Task<List<ImagesGos>> GetAll()
		{
			return await _context.ImagesGos.ToListAsync();
		}

		public async Task<ImagesGos> GetById(int id)
		{
			return await _context.ImagesGos.FirstOrDefaultAsync(a => a.IdImagesGo == id);
		}

		public async Task<ImagesGos> Post(ImagesGos obj)
		{
			 await _context.ImagesGos.AddAsync(obj);
			return obj;
		}



		public string Imago(IFormFile file, string savingFolder)
		{
				//if (savingFolder == null)
				//{
				//	savingFolder = Path.Combine("imgUpdated");
				//}

			var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), savingFolder);
			if (file.Length > 0)
			{
				var filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
				var fullpath = Path.Combine(pathToSave, filename);

				using (var stream = new FileStream(fullpath,FileMode.Create))
				{
					file.CopyTo(stream);
				}

				//return savingFolder + "/" +filename;

				return filename;
			}
			else
			{
				return null;
			}

		}
	}
}
