using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityCollectionBackendService.Models
{
    public class EntityCollectionItem
    {
        public int Id { get; set; }
        [ForeignKey("EntityCollection")]
        public int? EntityCollectionId { get; set; }
        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public string Name { get; set; }
        public EntityCollection EntityCollection { get; set; }
        public Category Category { get; set; }
        public string HtmlDescription { get; set; }
        public bool IsDeleted { get; set; }
    }
}
