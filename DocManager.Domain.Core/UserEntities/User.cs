using System.Collections.Generic;

namespace DocManager.Domain.Core.UserEntities
{
    public class User
    {
        public int Id { get; set; }

        public int FirstName { get; set; }

        public int LastName { get; set; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
