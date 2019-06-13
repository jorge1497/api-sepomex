using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace api_sepomex.Models
{
    [Table("Pais", Schema = "sepomex")]
    public class Country
    {
        [Column("PaisID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CountryID { get; set; }
        [Column("Nombre")]
        [MaxLength(200)]
        public string Name { get; set; }
        [Column("Codigo")]
        [MaxLength(2)]
        public string Code { get; set; }
        [Column("Moneda")]
        [MaxLength(5)]
        public string Currency { get; set; }
        [Column("CodMoneda")]
        [MaxLength(3)]
        public string CurrencyCode { get; set; }
        [Column("FechaUltimaModificacion")]
        public DateTime? LastChange { get; set; }
        [Column("UsuarioID")]
        public int? UserID { get; set; }
        [Column("Activo")]
        public bool? Active { get; set; }
    }
}