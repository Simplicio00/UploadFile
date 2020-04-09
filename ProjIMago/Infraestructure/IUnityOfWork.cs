using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjIMago.Infraestructure
{
	public interface IUnityOfWork
	{
		InterfaceImagesGo ImagesGoRepository { get; }
		void Save();
	}
}
