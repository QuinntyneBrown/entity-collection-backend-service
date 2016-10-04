using EntityCollectionBackendService.Dtos;
using EntityCollectionBackendService.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace EntityCollectionBackendService.Controllers
{
    [Authorize]
    [RoutePrefix("api/entityCollection")]
    public class EntityCollectionController : ApiController
    {
        public EntityCollectionController(IEntityCollectionService entityCollectionService)
        {
            _entityCollectionService = entityCollectionService;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(EntityCollectionAddOrUpdateResponseDto))]
        public IHttpActionResult Add(EntityCollectionAddOrUpdateRequestDto dto) { return Ok(_entityCollectionService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(EntityCollectionAddOrUpdateResponseDto))]
        public IHttpActionResult Update(EntityCollectionAddOrUpdateRequestDto dto) { return Ok(_entityCollectionService.AddOrUpdate(dto)); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<EntityCollectionDto>))]
        public IHttpActionResult Get() { return Ok(_entityCollectionService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(EntityCollectionDto))]
        public IHttpActionResult GetById(int id) { return Ok(_entityCollectionService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_entityCollectionService.Remove(id)); }

        protected readonly IEntityCollectionService _entityCollectionService;


    }
}
