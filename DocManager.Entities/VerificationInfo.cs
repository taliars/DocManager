using System;

namespace DocManager.Entities
{
    public class VerificationInfo
    { 
        public string Number { get; set; }

        public string Organization { get; set; }

        public DateTime Expiration { get; set; }
    }
}
