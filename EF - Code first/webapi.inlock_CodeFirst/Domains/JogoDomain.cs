using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock_CodeFirst.Domains
{
    [Table("Jogo")]
    public class JogoDomain
    {
        [Key]
        public Guid IdJogo { get; set; } = Guid.NewGuid();


        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome do jogo é obrigatório!")]
        public string? Nome { get; set; }


        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A descrição do jogo é obrigatória!")]
        public string? Descricao { get; set; }


        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data de lançamento do jogo é obrigatória!")]
        public DateTime DataLancamento { get; set; }


        [Column(TypeName = "Decimal(4,s2)")]
        [Required(ErrorMessage = "O preço do jogo é obrigatório!")]
        public decimal Preco { get; set; }


        // Foreign Key - Ref. Tabela de estudio:
        public Guid IdEstudio { get; set; }


        [ForeignKey("IdEstudio")]
        public EstudioDomain? Estudio { get; set; }
    }
}
