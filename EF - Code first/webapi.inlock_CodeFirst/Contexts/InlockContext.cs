using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using webapi.inlock_CodeFirst.Domains;

namespace webapi.inlock_CodeFirst.Contexts
{
    public class InlockContext : DbContext
    {
        /// <summary>
        /// Definição das entidades do banco de dados.
        /// </summary>
        public DbSet<TiposUsuarioDomain> TiposUsuario { get; set; } 

        public DbSet<UsuarioDomain> Usuario { get; set; }   

        public DbSet<EstudioDomain> Estudio { get; set; }   

        public DbSet<JogoDomain> Jogo { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE18-S14; Database=inlock_games_codeFirst_tarde; user id=sa; pwd=Senai@134; TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
