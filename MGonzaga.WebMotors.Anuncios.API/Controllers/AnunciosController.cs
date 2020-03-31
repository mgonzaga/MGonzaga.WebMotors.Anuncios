using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MGonzaga.WebMotors.Anuncios.API.Resources;
using MGonzaga.WebMotors.Anuncios.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MGonzaga.WebMotors.Anuncios.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnunciosController : ControllerBase
    {
        private readonly IAnuncioRepository _repository;
        public AnunciosController(IAnuncioRepository repository)
        {
            this._repository = repository;
        }
        // GET: api/Anuncios
        [HttpGet]
        public IEnumerable<Anuncio> Get()
        {
            var entities = _repository.ListarTodos();
            var retorno = new List<Anuncio>();
            foreach (var model in entities)
            {
                retorno.Add(new Anuncio().FromEntity(model));
            }
            return retorno;
        }

        // GET: api/Anuncios/5
        [HttpGet("{id}", Name = "Get")]
        public Anuncio Get(int id)
        {
            var entity = _repository.Consultar(id);
            return new Anuncio().FromEntity(entity);
        }

        // POST: api/Anuncios
        [HttpPost]
        public Anuncio Post([FromBody] Anuncio value)
        {
            var entity = value.ToEntity();
            entity = _repository.Adicionar(entity);
            return value.FromEntity(entity);
        }

        // PUT: api/Anuncios/5
        [HttpPut("{id}")]
        public Anuncio Put(int id, [FromBody] Anuncio value)
        {
            var entity = value.ToEntity();
            entity.Id = id;
            entity = _repository.Atualizar(entity);
            return value.FromEntity(entity);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Remover(id);
        }
    }
}
