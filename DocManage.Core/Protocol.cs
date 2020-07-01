using System.Collections.Generic;

namespace DocManager.Core
{
    public class Protocol : Document
    {
        public static string GetName(string species, string order)
        {
            var dictionary = new Dictionary<string, string>
            {
                ["шум"] = $"001шм-{order}-20",
                ["шум жд"] = $"001шм-{order}-20",
                ["шум авиа"] = $"001шм-{order}-20",
                ["инфразвук"] = $"001иф-{order}-20",
                ["вибрация"] = $"001вб-{order}-20",
                ["эми"] = $"001эм-{order}-20",
                ["радиация"] = $"001пр-{order}-20",
                ["радионуклиды"] = $"001рд-{order}-20",
                ["почва"] = $"001пч-{order}-20",
                ["воздух"] = $"001вз-{order}-20",
            };

            return dictionary[species.ToLower()];
        }
    }
}