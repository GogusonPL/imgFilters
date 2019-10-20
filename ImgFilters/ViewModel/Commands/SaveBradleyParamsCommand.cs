using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ImgFilters.ViewModel.Commands
{
    public class SaveBradleyParamsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public ImgFiltersVM VM { get; set; }
        public SaveBradleyParamsCommand(ImgFiltersVM vm)
        {
            VM = vm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            SaveFileDialog dialog_window = new SaveFileDialog();
            dialog_window.Filter = "XML Files (*.xml)|*.xml";
            dialog_window.FilterIndex = 0;
            dialog_window.DefaultExt = "xml";
            if (dialog_window.ShowDialog() == true)
            {
                string filePath = dialog_window.FileName;
                FileManager.WriteToXmlFile(filePath, VM.BradleyParams);

            }
        }
    }
}
