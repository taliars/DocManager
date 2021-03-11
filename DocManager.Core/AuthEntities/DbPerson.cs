using DocManager.Core.AuthEntities;

namespace DocManager.Domain.Core.UserEntities
{
    public class DbPerson
    {
        public int Id { get; set; }

        public int SubscriptionId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public int LoginId { get; set; }

        public virtual DbLogin Login { get; set; }

        public int PositionId { get; set; }

        public virtual DbPosition Position { get; set; }
    }
}
