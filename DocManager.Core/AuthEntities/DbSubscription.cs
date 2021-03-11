    using System.Collections.Generic;

namespace DocManager.Domain.Core.UserEntities
{
    public class DbSubscription
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<DbPerson> Users { get; set; }
    }
}
