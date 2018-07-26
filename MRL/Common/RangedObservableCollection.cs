using System.Collections.ObjectModel;

namespace MRL.Common
{
    public class RangedObservableCollection<T> : ObservableCollection<T>
    {
        public void AddRange(RangedObservableCollection<T> collection)
        {
            this.Clear();

            foreach (var item in collection)
            {
                this.Add(item);
            }
        }            
    }
}
