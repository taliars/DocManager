using MahApps.Metro.Controls.Dialogs;

namespace DocManager.View
{
    public static class DialogSettings
    {
        public static readonly MetroDialogSettings Standard = new MetroDialogSettings
        {
            AffirmativeButtonText = "OK",
            NegativeButtonText = "Отмена",
            AnimateShow = false,
            AnimateHide = false,
        };
    }
}
