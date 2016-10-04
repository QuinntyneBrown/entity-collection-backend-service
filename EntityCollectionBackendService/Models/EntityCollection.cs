using System.Collections;
using System.Collections.Generic;

namespace EntityCollectionBackendService.Models
{
    public class EntityCollection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HtmlDescription { get; set; }
        public ICollection<EntityCollectionItem> EntityCollectionItems { get; set; } = new System.Collections.Generic.HashSet<EntityCollectionItem>();
        public bool IsDeleted { get; set; }
    }
}
