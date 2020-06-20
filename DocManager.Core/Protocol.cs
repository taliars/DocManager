using System.Collections.Generic;

namespace DocManager.Core
{
    public class Protocol : Document
    {
        public static string GetName(string species, string order)
        {
            var dictionary = new Dictionary<string, string>
            {
                ["���"] = $"001��-{order}-20",
                ["��� ��"] = $"001��-{order}-20",
                ["��� ����"] = $"001��-{order}-20",
                ["���������"] = $"001��-{order}-20",
                ["��������"] = $"001��-{order}-20",
                ["���"] = $"001��-{order}-20",
                ["��������"] = $"001��-{order}-20",
                ["������������"] = $"001��-{order}-20",
                ["�����"] = $"001��-{order}-20",
                ["������"] = $"001��-{order}-20",
            };

            return dictionary[species.ToLower()];
        }
    }
}