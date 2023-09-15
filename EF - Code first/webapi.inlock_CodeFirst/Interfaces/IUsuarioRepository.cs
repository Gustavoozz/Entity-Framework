using webapi.inlock_CodeFirst.Domains;

namespace webapi.inlock_CodeFirst.Interfaces
{
    public interface IUsuarioRepository
    {
        UsuarioDomain BuscarUsuario(string email, string senha);

        public void Cadastrar(UsuarioDomain usuario);
    }
}
