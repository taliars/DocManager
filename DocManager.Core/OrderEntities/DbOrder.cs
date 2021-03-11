using DocManager.Domain.Core.UserEntities;

namespace DocManager.Domain.Core.OrderEntities
{
    public class DbOrder
    {
        public int Id { get; set; }

        public int SubscriptionId { get; set; }

        public virtual DbSubscription Subscription { get; set; }

        public int ObjectDataId { get; set; }

        public virtual DbObjectData ObjectData { get; set; }

        public int CustomerId { get; set; }

        public virtual DbCustomer Customer { get; set; }
    }
}
