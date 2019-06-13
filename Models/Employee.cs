using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace api_sepomex.Models
{
    [Table("Empleado", Schema = "sepomex")]
    public class Employee
    {
        [Column("EmpleadoId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        [Column("PrimerNombre")]
        public string FirstName { get; set; }
        [Column("ApellidoPaterno")]
        public string LastName { get; set; }
        [Column("LugarDeNacimiento")]
        public string POB { get; set; }
        [Column("FechaUltimaModificacion")]
        public DateTime LastChange { get; set; }
        [Column("UsuarioId")]
        public int? UserID { get; set; }
        [Column("Activo")]
        public bool Active { get; set; }
        [Column("Foto")]
        public string ImageData { get; set; }
    }
}