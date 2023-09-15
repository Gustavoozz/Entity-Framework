
using webapi.inlock_CodeFirst.Contexts;
using webapi.inlock_CodeFirst.Domains;
using webapi.inlock_CodeFirst.Interfaces;
using webapi.inlock_CodeFirst.Utils;

namespace webapi.inlock.codeFirst.tarde.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly InlockContext ctx;

        public UsuarioRepository()
        {
            ctx = new InlockContext();
        }

        public UsuarioDomain BuscarUsuario(string email, string senha)
        {
            try
            {
                UsuarioDomain usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.Email == email)!;

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if (confere)
                    {
                        return usuarioBuscado;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(UsuarioDomain usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha);

                ctx.Usuario.Add(usuario);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}