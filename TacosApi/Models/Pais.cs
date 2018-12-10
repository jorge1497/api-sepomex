using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TacosApi.Models
{
    public class Pais
    {
	    public int? PaisID {get; set;}
	    public string Nombre {get; set;}
	    public string Codigo {get; set;}
	    public string  Moneda {get; set;}
	    public string  CodMoneda {get; set;}
	    public DateTime? FechaUltimaModificacion {get; set;}
	    public int? UsuarioID {get; set;}
        public bool? Activo { get; set; }
    }
}