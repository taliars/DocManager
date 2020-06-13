using System;
using System.Collections.Generic;

namespace DocManager.Core
{
    public class Act : Document
    {
        public Act New(string species, DateTime? dateTime, string order, string performer = "������� �.�.")
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
                ["�����"] = $"001��-{order}-20",
                ["��������� ����"] = $"001��-{order}-20",
                ["������� ����"] = $"001��-{order}-20",
                ["������ ���������"] = $"001��-{order}-20",
                ["������"] = $"001��-{order}-20",
                ["����������� ������"] = $"001��-{order}-20",
                ["������"] = $"001��-{order}-20",
            };

            return dictionary[species];
        }
    }
}