using webapi.inlock_CodeFirst.Domains;

namespace webapi.inlock_CodeFirst.Interfaces
{
    public interface IJogoRepository
    {
        List<JogoDomain> Listar();

        JogoDomain BuscarPorId(Guid id);

        void Cadastrar(JogoDomain jogo);

        void Atualizar(Guid id, JogoDomain jogo);

        void Deletar(Guid id);

        List<JogoDomain> ListarComJogos();
    }
}
