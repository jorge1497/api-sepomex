using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_sepomex.Models
{
    [Table("Usuario", Schema = "dbo")]
    public class User
    {
        [Column("UsuarioId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("Nombre")]
        public string FirstName { get; set; }
        [NotMapped]
        [Column("Nombre")]
        public string LastName { get; set; }
        [Column("Nombre")]
        public string Username { get; set; }
        [Column("Pass")]
        public string Password { get; set; }
        [NotMapped]
        public string Token { get; set; }
        [Column("Activo")]
        public bool IsAuth { get; set; }

    }
}