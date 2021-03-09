using System.Collections.Generic;

namespace DocManager.Domain.Core.UserEntities
{
    public class DbUser
    {
        public int Id { get; set; }

        public int SubscriptionId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public virtual ICollection<DbPerfomerRole> Roles { get; set; }
    }
}
