using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using TacosApi.Models;

namespace TacosApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    public class PaisController : ApiController
    {
        // GET api/pais
        public List<Pais> Get()
        {
            using (var _context = new TacosApi.DAL.TacosContext())
            {
                return _context.Paises.ToList();
            }
        }

        // GET api/pais/5
        public Pais Get(int id)
        {
            using (var _context = new TacosApi.DAL.TacosContext())
            {
                return _context.Paises.ToList().Where<Pais>(t => t.PaisID == id).FirstOrDefault();
            }
        }

        // POST api/pais
        public List<Pais> Post([FromBody]Pais Pais)
        {
            using (var _context = new TacosApi.DAL.TacosContext())
            {
                _context.Paises.Add(Pais);
                _context.SaveChanges();

                return _context.Paises.ToList();
            }
        }

        // PUT api/pais/5
        public List<Pais> Put(int id, [FromBody]Pais pais)
        {
            using (var _context = new TacosApi.DAL.TacosContext())
            {
                var updPais = _context.Paises.Where<Pais>(t => t.PaisID == id).FirstOrDefault();

                if (updPais != null)
                {
                    updPais.Codigo = pais.Codigo;
                    updPais.CodMoneda = pais.CodMoneda;
	                updPais.FechaUltimaModificacion = DateTime.Now;
                    updPais.Activo = pais.Activo;
                    updPais.Nombre = pais.Nombre;
                    updPais.Moneda = pais.Moneda;

                    _context.SaveChanges();
                }

                return _context.Paises.ToList();
            }
        }

        // DELETE api/pais/5
        public List<Pais> Delete(int id)
        {
            using (var _context = new TacosApi.DAL.TacosContext())
            {
                var delPais = _context.Paises.Where<Pais>(t => t.PaisID == id).FirstOrDefault();

                if (delPais != null)
                {
                    _context.Paises.Remove(delPais);

                    _context.SaveChanges();

                }

                return _context.Paises.ToList();
            }
        }
    }
}
