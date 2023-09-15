using webapi.inlock_CodeFirst.Contexts;
using webapi.inlock_CodeFirst.Domains;
using webapi.inlock_CodeFirst.Interfaces;

namespace webapi.inlock_CodeFirst.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private readonly InlockContext ctx;
        public EstudioRepository()
        {
            ctx = new InlockContext();
        }
        public void Atualizar(Guid id, EstudioDomain estudio)
        {
            throw new NotImplementedException();
        }

        public EstudioDomain BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(EstudioDomain estudio)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<EstudioDomain> Listar()
        {
            throw new NotImplementedException();
        }

        public List<EstudioDomain> ListarComJogos()
        {
            throw new NotImplementedException();
        }
    }
}
