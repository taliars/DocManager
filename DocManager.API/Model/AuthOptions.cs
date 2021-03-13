using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DocManager.API.Models
{
    public class AuthOptions
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string Secret { get; set; }

        public double LifetimeInHours { get; set; }

        public SymmetricSecurityKey SymmetricSecurityKey
            => new(Encoding.ASCII.GetBytes(Secret));
    }
}
