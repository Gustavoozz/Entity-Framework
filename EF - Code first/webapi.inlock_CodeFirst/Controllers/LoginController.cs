using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.inlock.codeFirst.tarde.Repositories;
using webapi.inlock_CodeFirst.Domains;
using webapi.inlock_CodeFirst.Interfaces;
using webapi.inlock_CodeFirst.ViewModels;

namespace webapi.inlock_CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        
        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel usuario)
        {
            try
            {
               UsuarioDomain usuarioBuscado =  _usuarioRepository.BuscarUsuario(usuario.Email!, usuario.Senha!);

                if (usuarioBuscado == null)
                {
                    return NotFound("Email ou senha inválidos. Tente novamente!");
                }

                // Caso encontre o usuário buscado, prossegue para a criação do Token.

                // 1 - Definir as informações ( Claims ) que serão fornecidos no Token ( Payload ):
                var claims = new[]
                {
                    // Formato da claim ( Tipo, valor ).
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email!),
                    

                    // Existe a possibilidade de criar uma claim personalizada.
                    new Claim("Claim Personalziada", "Valor Personalizado")
                };

                // 2 - Definir a chave de acesso ao Token:
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("jogos.chave.autenticacao-webapi-dev"));


                // 3 - Definir as credenciais do Token ( Header ):
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // 4 - Gerar o token:
                var token = new JwtSecurityToken
                (

                // Emissor do token:
                issuer: "webapi.inlock_CodeFirst",

                // Destinatário:
                audience: "webapi.inlock_CodeFirst",

                //Dados definidos nas claims:
                claims: claims,

                // Tempo de expiração:
                expires: DateTime.Now.AddMinutes(5),

                // Credênciais do Token:
                signingCredentials: creds

                );

                // 5 - Retornar o token criado:
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                });
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);

            }
        }

    }
}
