using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualStudio.TemplateWizard;
using EnvDTE;
namespace ClimaControl_ConfigurableItemWizard
{
    public class ConfigurableItemWizard:IWizard
    {
        private ConfigurableItemWizardForm _form;
        private string customMessage;
        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind,
            object[] customParams)
        {
            try
            {
                // Display a form to the user. The form collects   
                // input for the custom message.  
                _form = new ConfigurableItemWizardForm();
                _form.ShowDialog();

                customMessage = "hhhh";//ConfigurableItemWizardForm.CustomMessage;

                // Add custom parameters.  
                replacementsDictionary.Add("$custommessage$",
                    customMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void ProjectFinishedGenerating(Project project)
        {
            
        }

        public void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
            
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }

        public void BeforeOpeningFile(ProjectItem projectItem)
        {
            
        }

        public void RunFinished()
        {
            
        }
    }
}