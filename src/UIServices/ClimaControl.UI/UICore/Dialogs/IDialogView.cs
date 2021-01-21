namespace ClimaControl.UI.UICore.Dialogs
{
    public interface IDialogView
    {
        bool? ShowDialog();
        object DataContext { get; set; }
    }
}