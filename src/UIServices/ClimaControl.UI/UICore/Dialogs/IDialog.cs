namespace ClimaControl.UI.UICore.Dialogs
{
    public interface IDialog
    {
        bool? ShowDialog();
        string Title { get; set; }
        DialogResult Result { get; }
        
    }
}