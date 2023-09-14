using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock_CodeFirst.Domains
{
    [Table("TiposUsuarios")]
    public class TiposUsuarioDomain
    {
        [Key]
        public Guid IdTiposUsuario { get; set; } = Guid.NewGuid();
        


        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome do tipo de usuário é obrigatório!")]
        public string? Titulo { get; set; }
    }
}
