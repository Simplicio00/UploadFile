using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjIMago.Infraestructure;
using ProjIMago.Models;

 namespace ProjIMago.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ImagosController : ControllerBase
    {
        private IUnityOfWork unityOfWork;

        public ImagosController(IUnityOfWork _unityOfWork)
        {
            unityOfWork = _unityOfWork;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lista = await unityOfWork.ImagesGoRepository.GetAll();
            IActionResult action = NoContent();
            if (lista.Count != 0)
            {
                return Ok(lista);
            }
            return action;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromForm]ImagesGos obj)
        {
            IActionResult result = Forbid();
            var arquivo = Request.Form.Files[0];
            obj.Imagego = unityOfWork.ImagesGoRepository.Imago(arquivo, "arch");
            obj.Description = Request.Form["Description"];

            try
            {
                if (obj.Imagego == null)
                {
                    return result;
                }

                await unityOfWork.ImagesGoRepository.Post(obj);
                unityOfWork.Save();
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }


    }
}