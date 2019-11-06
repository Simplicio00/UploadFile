using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tst.Models;
using tst.Repositorio;

namespace tst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        UploadRepositorio uploadRepositorio = new UploadRepositorio();

        UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
        

        [HttpPost]
        public async Task<ActionResult<Usuario>> Post([FromForm] Usuario usuario){
            try
            {
                var arquivo = Request.Form.Files[0];
                
                // Gerar objeto com os dados no formulário
                usuario.ImagemUsuario = uploadRepositorio.Upload(arquivo,"UsuarioImagens");
                usuario.Email = Request.Form["email"];
                usuario.Senha = Request.Form["senha"];
                await usuarioRepositorio.Salvar(usuario);
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return usuario;
        }


    }
}