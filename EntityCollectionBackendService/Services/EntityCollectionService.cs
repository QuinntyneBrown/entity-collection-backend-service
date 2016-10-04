using System;
using System.Collections.Generic;
using EntityCollectionBackendService.Dtos;
using EntityCollectionBackendService.Data;
using System.Linq;

namespace EntityCollectionBackendService.Services
{
    public class EntityCollectionService : IEntityCollectionService
    {
        public EntityCollectionService(IUow uow, ICacheProvider cacheProvider)
        {
            _uow = uow;
            _repository = uow.EntityCollections;
            _cache = cacheProvider.GetCache();
        }

        public EntityCollectionAddOrUpdateResponseDto AddOrUpdate(EntityCollectionAddOrUpdateRequestDto request)
        {
            var entity = _repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) _repository.Add(entity = new Models.EntityCollection());
            entity.Name = request.Name;
            _uow.SaveChanges();
            return new EntityCollectionAddOrUpdateResponseDto(entity);
        }

        public ICollection<EntityCollectionDto> Get()
        {
            ICollection<EntityCollectionDto> response = new HashSet<EntityCollectionDto>();
            var entities = _repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach (var entity in entities) { response.Add(new EntityCollectionDto(entity)); }
            return response;
        }

        public EntityCollectionDto GetById(int id)
        {
            return new EntityCollectionDto(_repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            _uow.SaveChanges();
            return id;
        }

        protected readonly IUow _uow;
        protected readonly IRepository<Models.EntityCollection> _repository;
        protected readonly ICache _cache;
    }
}
