using System;

namespace ClimaControl.UI.UICore.Dialogs.Models
{
    
    public interface IMessageDialog:IDialog
    {
        
        string Message { get; set; }
        DialogButton Buttons { get; set; }
        
    }
}