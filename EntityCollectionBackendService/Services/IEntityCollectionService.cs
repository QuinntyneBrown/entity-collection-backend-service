using EntityCollectionBackendService.Dtos;
using System.Collections.Generic;

namespace EntityCollectionBackendService.Services
{
    public interface IEntityCollectionService
    {
        EntityCollectionAddOrUpdateResponseDto AddOrUpdate(EntityCollectionAddOrUpdateRequestDto request);
        ICollection<EntityCollectionDto> Get();
        EntityCollectionDto GetById(int id);
        dynamic Remove(int id);
    }
}
