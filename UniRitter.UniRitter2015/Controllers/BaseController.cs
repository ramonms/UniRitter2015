using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using UniRitter.UniRitter2015.Models;
using UniRitter.UniRitter2015.Services;

namespace UniRitter.UniRitter2015.Controllers
{
    abstract public class BaseController<TModel> : ApiController
        where TModel: class, IModel
    {
        public IRepository<TModel> _repo;

        public BaseController()  {
            
        }

        public BaseController(IRepository<TModel> repositorio)  {
            this._repo = repositorio;
        }

        // GET: api/Post
        public async Task<IHttpActionResult> Get()  {
            return Json(await _repo.GetAll());
        }


        // GET: api/Post/5
        public async Task<IHttpActionResult> Get(Guid id)    {
            var dados = await _repo.GetById(id);
            if (dados != null)     {
                return Json(dados);
            }
            return NotFound();
        }

        // POST: api/Post
        public virtual async Task<IHttpActionResult> Post([FromBody]TModel post)
        {
            if (ModelState.IsValid)
            {
                var dados = await _repo.Add(post);
                return Json(dados);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Post/5
        public virtual async Task<IHttpActionResult> Put(Guid id, [FromBody]TModel post)
        {
            var data = await _repo.Update(id, post);
            return Json(post);
        }

        // DELETE: api/Post/5
        public virtual async Task<IHttpActionResult> Delete(Guid id)
        {
            await _repo.Delete( id );
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
