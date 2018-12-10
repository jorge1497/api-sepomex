using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using TacosApi.Models;
using System.Web.Http.Cors;

namespace TacosApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    public class TacosController : ApiController
    {
        // GET api/tacos
        public List<TipoTaco> Get()
        {
            using (var _context = new TacosApi.DAL.TacosContext())
            {
                return _context.TiposDeTaco.ToList();
            }
        }

        // GET api/tacos/5
        public TipoTaco Get(int id)
        {
            using (var _context = new TacosApi.DAL.TacosContext())
            {
                return _context.TiposDeTaco.ToList().Where<TipoTaco>(t => t.id == id).FirstOrDefault();
            }
        }

        // POST api/tacos
        public List<TipoTaco> Post([FromBody]TipoTaco tipoTaco)
        {
            using (var _context = new TacosApi.DAL.TacosContext())
            {
                _context.TiposDeTaco.Add(tipoTaco);
                _context.SaveChanges();

                return _context.TiposDeTaco.ToList();
            }            
        }

        // PUT api/tacos/5
        public List<TipoTaco> Put(int id, [FromBody]TipoTaco tipoTaco)
        {
            using (var _context = new TacosApi.DAL.TacosContext())
            {
                var updTipoTaco = _context.TiposDeTaco.Where<TipoTaco>(t => t.id==id).FirstOrDefault();

                if (updTipoTaco != null) {
                    updTipoTaco.name = tipoTaco.name;
                    updTipoTaco.description = tipoTaco.description;

                    _context.SaveChanges();
                }

                return _context.TiposDeTaco.ToList();
            }
        }

        // DELETE api/tacos/5
        public List<TipoTaco> Delete(int id)
        {
            using (var _context = new TacosApi.DAL.TacosContext())
            {
                var delTipoTaco = _context.TiposDeTaco.Where<TipoTaco>(t => t.id == id).FirstOrDefault();

                if (delTipoTaco != null)
                {
                    _context.TiposDeTaco.Remove(delTipoTaco);

                    _context.SaveChanges();

                }

                return _context.TiposDeTaco.ToList();
            }
        }
    }
}