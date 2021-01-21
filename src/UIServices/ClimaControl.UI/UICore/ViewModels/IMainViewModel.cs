namespace ClimaControl.UI.UICore.ViewModels
{
    public interface IMainViewModel:IViewModel
    {
        string Title { get; set; }
        string StatusString { get; set; }
    }
}