namespace ClimaControl.UI.Util
{
    public interface IViewModelAssignator
    {
        void AssignViewModel(object component, object[] arguments);
        void AssignDialogParrent(object component, object parent);
    }
}