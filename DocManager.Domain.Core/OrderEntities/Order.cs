using System.Collections.Generic;

namespace DocManager.Domain.Core.OrderEntities
{
    public class Order
    {
        public int Id { get; set; }

        public ObjectData ObjectData { get; set; }

        public virtual ICollection<Document> Documents { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}
