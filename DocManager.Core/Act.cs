using System;
using System.Collections.Generic;

namespace DocManager.Core
{
    public class Act : Document
    {
        public Act New(string species, DateTime? dateTime, string order, string performer = "Астахов П.Ю.")
        {
            return new Act
            {
                Species = species,
                Path = "not specified",
                Date = dateTime,
                Dates = dateTime.ToString(),
                Name = GetNameForDocument(species, order),
                Perfomer = performer,
            };
        }

        protected override string GetNameForDocument(string species, string order)
        {
            var dictionary = new Dictionary<string, string>
            {
                ["Почва"] = $"001пч-{order}-20",
                ["Природная вода"] = $"001пв-{order}-20",
                ["Сточная вода"] = $"001св-{order}-20",
                ["Донные отложения"] = $"001до-{order}-20",
                ["Воздух"] = $"001ав-{order}-20",
                ["Атмосферные осадки"] = $"001ао-{order}-20",
                ["Отходы"] = $"001от-{order}-20",
            };

            return dictionary[species];
        }
    }
}