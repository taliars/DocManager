using System;

namespace DocManager.Core.OrderEntities
{
    public class DbVerificationInfo
    {
        public int Id { get; set; }

        public int SubscriptionId { get; set; }

        public string Number { get; set; }

        public string Organization { get; set; }

        public DateTime Expiration { get; set; }
    }
}