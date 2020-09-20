using System.Collections.ObjectModel;
using DocManager.Abstractions;
using DocManager.Core;
using DocManager.ViewModel.Common;

namespace DocManager.ViewModel.ViewModels
{
    public class DocumentViewModel : PropertyChangedBase
    {
        private Document selectedDocument;

        public ObservableCollection<Document> Documents { get; set; }

        public RelayCommand Add{ get; }

        public RelayCommand Remove { get; }

        public RelayCommand Open { get; }

        public RelayCommand Move { get; }

        public Document SelectedDocument
        {
            get => selectedDocument;
            set
            {
                selectedDocument = value;
                NotifyPropertyChanged(nameof(SelectedDocument));
            }
        }

        public DocumentViewModel(IDocumentActionHelper documentActionHelper)
        {
            Add = new RelayCommand(o => documentActionHelper.Add(o, Documents, nameof(Documents)));
            Remove = new RelayCommand(o => documentActionHelper.Remove(o, Documents, nameof(Documents)));
            Open = new RelayCommand(async o => await documentActionHelper.OpenWithDefaultAppAsync((Document)o));
            Move = new RelayCommand(async o => await documentActionHelper.MoveAsync(SelectedDocument, Documents, nameof(Documents)));
        }
    }
}
