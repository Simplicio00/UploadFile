using System.Threading.Tasks;
using tst.Interfaces;
using tst.Models;

namespace tst.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        TwContext context = new TwContext();


        public async Task<Usuario> Salvar(Usuario usuario)
        {
          await context.AddAsync(usuario);
          await context.SaveChangesAsync();
             return usuario;
        }
    }
}