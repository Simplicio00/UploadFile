using ProjIMago.Data;
using ProjIMago.Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjIMago.Services
{
	public class UnityOfWork : IUnityOfWork
	{
		private IMagoContext context;
		private InterfaceImagesGo imagesGoRepository;

		public UnityOfWork(IMagoContext _context)
		{
			context = _context;
		}

		public InterfaceImagesGo ImagesGoRepository { get { return imagesGoRepository ?? new ImagesGoRepository(context); } } 



		public void Save()
		{
			context.SaveChangesAsync();
		}
	}
}
