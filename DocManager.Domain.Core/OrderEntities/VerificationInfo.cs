using System;

namespace DocManager.Domain.Core.OrderEntities
{
    public class VerificationInfo
    {
        public string VerificationNumber { get; set; }

        public string VerificationOrganization { get; set; }

        public DateTime VerificationExpiration { get; set; }
    }
}