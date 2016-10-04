using System.Collections.Generic;

namespace EntityCollectionBackendService.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HtmlDescription { get; set; }
        public ICollection<EntityCollectionItem> EntityCollectionItems { get; set; } = new HashSet<EntityCollectionItem>();
        public bool IsDeleted { get; set; }
    }
}
