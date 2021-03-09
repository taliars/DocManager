using DocManager.Domain.Core.UserEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocManager.Domain.Core.OrderEntities
{
    public class DbOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int SubscriptionId { get; set; }

        public virtual DbSubscription Subscription { get; set; }

        public virtual DbObjectData ObjectData { get; set; }

        public virtual DbCustomer Customer { get; set; }
    }
}
