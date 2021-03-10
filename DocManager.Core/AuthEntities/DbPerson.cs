namespace DocManager.Core.AuthEntities
{
    public class DbPerson
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }
    }
}
