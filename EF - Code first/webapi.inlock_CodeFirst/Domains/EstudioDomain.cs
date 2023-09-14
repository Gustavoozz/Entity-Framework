using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock_CodeFirst.Domains
{
    [Table("Estudio")]
    public class EstudioDomain
    {
        [Key]
        public Guid IdEstudio { get; set; } = Guid.NewGuid();


        [Column(TypeName = "VARCHSAR(100)")]
        [Required(ErrorMessage = "Nome obrigatório!")]
        public string? Nome { get; set; }


        // Ref. Lista de jogos.
        public List<JogoDomain>? Jogo { get; set; }
    }
}
