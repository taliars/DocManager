using System.Collections.Generic;

namespace DocManager.Domain.Core.UserEntities
{
    public class Company
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
