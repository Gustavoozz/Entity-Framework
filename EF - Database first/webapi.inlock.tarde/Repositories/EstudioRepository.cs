using Microsoft.EntityFrameworkCore;
using webapi.inlock.tarde.Contexts;
using webapi.inlock.tarde.Domains;
using webapi.inlock.tarde.Interfaces;

namespace webapi.inlock.tarde.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        // Instanciar e estabelecer a conexão com a Context que tem a função de acessar o BD.
        InLockContext ctx = new InLockContext();
        public void Atualizar(Guid id, Estudio estudio)
        {
            Estudio estudioBuscado = ctx.Estudios.Find(id)!;

            if (estudioBuscado != null)
            {
                estudioBuscado.Nome = estudio.Nome;
            }

            ctx.Estudios.Update(estudioBuscado!);

            ctx.SaveChanges();
        }

        public Estudio BuscarPorId(Guid id)
        {
            return ctx.Estudios.FirstOrDefault(a => a.IdEstudio == id);
        }


            
        public void Cadastrar(Estudio estudio)
        {
            ctx.Estudios.Add(estudio);

            ctx.SaveChanges();
        }


        /// <summary>
        /// Método responsável por deletar um estúdio.
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(Guid id)
        {
           Estudio estudioBuscado = ctx.Estudios.Find(id);

            if (estudioBuscado != null)
            {
                ctx.Estudios.Remove(estudioBuscado);
            }

            ctx.SaveChanges();
        }

        /// <summary>
        /// Método responsável por listar os estúdios.
        /// </summary>
        /// <returns></returns>
        public List<Estudio> Listar()
        {
            return ctx.Estudios.ToList();
        }

        /// <summary>
        /// Método responsável por listar os estúdios juntamente aos jogos.
        /// </summary>
        /// <returns></returns>
        public List<Estudio> ListarComJogos()
        {
            return ctx.Estudios.Include(x => x.Jogos).ToList();  
        }
    }
}
