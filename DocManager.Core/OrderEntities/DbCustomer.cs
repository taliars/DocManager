using DocManager.Domain.Core.UserEntities;

namespace DocManager.Domain.Core.OrderEntities
{
    public class DbCustomer
    {
        public int Id { get; set; }

        public int SubscriptionId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Ogrn { get; set; }

        public string Inn { get; set; }
    }
}