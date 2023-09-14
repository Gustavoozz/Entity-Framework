using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock_CodeFirst.Domains
{
    [Table("Usuario")]
    public class UsuarioDomain
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();


        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O e-mail do usuário é obrigatório!")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string? Email { get; set; }


        [Column(TypeName = "VARCHAR(200)")]
        [Required(ErrorMessage = "A senha do usuário é obrigatória!")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "Senha deve conter de 6 a 60 caractéres.")]
        public string? Senha { get; set; }


        // Ref. Tabela Tipos de Usuario.
        [Required(ErrorMessage = "O tipo de usuário é obrigatório!")]
        public Guid IdTipoUsuario { get; set; }


        [ForeignKey("IdTipoUsuario")]
        public TiposUsuarioDomain? TiposUsuario { get; set; }
    }
}
