using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;

namespace DocManager.ViewModel
{
    public static class Lists
    {

        public static IEnumerable<object> WindDirections { get; } = new ObservableCollection<object>()
        {
            "C",
            "CCВ",
            "СВ",
            "ВСВ",
            new Separator(),
            "В",
            "ВЮВ",
            "ЮВ",
            "ЮЮВ",
            new Separator(),
            "Ю",
            "ЮЮЗ",
            "ЮЗ",
            "ЗЮЗ",
            new Separator(),
            "З",
            "ЗСЗ",
            "СЗ",   
            "ССЗ"         
        };

        public static List<int> WindSpeed { get; set; } = Enumerable.Range(0, 6).ToList();
        public static List<int> Cloudness { get; set; } = Enumerable.Range(0, 11).ToList();
        public static List<int> Moisture { get; set; } = Enumerable.Range(0, 101).ToList();
    }
}
