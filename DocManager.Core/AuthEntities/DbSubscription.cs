using System.Collections.Generic;

namespace DocManager.Core.AuthEntities
{
    public class DbSubscription
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<DbPerson> Users { get; set; }
    }
}
