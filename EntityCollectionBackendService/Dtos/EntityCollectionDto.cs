namespace EntityCollectionBackendService.Dtos
{
    public class EntityCollectionDto
    {
        public EntityCollectionDto()
        {

        }

        public EntityCollectionDto(Models.EntityCollection entity)
        {
            Id = entity.Id;
            Name = entity.Name;
        }

        public int? Id { get; set; }
        public string Name { get; set; }
    }
}
