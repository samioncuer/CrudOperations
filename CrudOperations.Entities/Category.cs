using System;

namespace CrudOperations.Entities
{
    public class Category : BaseEntity
    {
        public int ParentId { get; set; } 
        public string Name { get; set; } 
    }
}
