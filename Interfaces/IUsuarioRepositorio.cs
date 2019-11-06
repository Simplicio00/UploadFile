using System.Threading.Tasks;
using tst.Models;

namespace tst.Interfaces
{
    public interface IUsuarioRepositorio
    {

         public Task<Usuario> Salvar(Usuario usuario);
    }
}