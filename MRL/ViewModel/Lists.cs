using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;

namespace MRL.ViewModel
{
    public static class Lists
    {
        #region weather

        public static ObservableCollection<object> winddirections { get; set; } = new ObservableCollection<object>()
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
        public static List<int> winddspeed { get; set; } = Enumerable.Range(0, 6).ToList();
        public static List<int> cloudness { get; set; } = Enumerable.Range(0, 11).ToList();
        public static List<int> moisture { get; set; } = Enumerable.Range(0, 101).ToList();

        #endregion
    }
}
