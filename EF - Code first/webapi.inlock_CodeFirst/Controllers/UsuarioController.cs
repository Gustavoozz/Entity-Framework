using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.inlock.codeFirst.tarde.Repositories;
using webapi.inlock_CodeFirst.Domains;
using webapi.inlock_CodeFirst.Interfaces;
using webapi.inlock_CodeFirst.Repositories;

namespace webapi.inlock_CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }


        [HttpPost]
        public IActionResult Post(UsuarioDomain usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);

                return Ok(usuario);
            }
            catch (Exception)
            {

                throw;
            }
        }


     
    }
}
