namespace DocManager.Domain.Core.OrderEntities
{
    public class ObjectData
    {
        public int Id { get; set; }

        public int SubscriptionId { get; set; }

        public int OrderId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Measurement { get; set; }

        public string Purpose { get; set; }

        public string Comment { get; set; }
    }
}