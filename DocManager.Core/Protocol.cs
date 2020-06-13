using System;
using System.Collections.Generic;

namespace DocManager.Core
{
    public class Protocol : Document
    {
        protected override string GetNameForDocument(string species, string order)
        {
            var dictionary = new Dictionary<string, string>
            {
                ["Шум"] = $"001шм-{order}-20",
                ["Инфразвук"] = $"001иф-{order}-20",
                ["Вибрация"] = $"001вб-{order}-20",
                ["ЭМИ 50 Гц"] = $"001эм-{order}-20",
                ["Радиация"] = $"001пр-{order}-20",
                ["Радионуклиды"] = $"001рд-{order}-20",
                ["Почва"] = $"001пч-{order}-20",
                ["Воздух"] = $"001вз-{order}-20",
            };

            return dictionary[species];
        }

        public Protocol New(string species, DateTime? dateTime, string order, string performer = "Астахов П.Ю.")
        { 
            return new Protocol
            {
                Species = species,
                Path = "not specified",
                Date = dateTime,
                Dates = dateTime.ToString(),
                Name = GetNameForDocument(species, order),
                Perfomer = performer,
            };
        }
    }
}