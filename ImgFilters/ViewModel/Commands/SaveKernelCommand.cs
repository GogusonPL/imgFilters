using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ImgFilters.ViewModel.Commands
{
    public class SaveKernelCommand : ICommand
    {
        
        public event EventHandler CanExecuteChanged;

        public ImgFiltersVM VM { get; set; }
        public SaveKernelCommand(ImgFiltersVM vm)
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
            if (dialog_window.ShowDialog() == true)
            {
                string filePath = dialog_window.FileName;
                FileManager.WriteToBinaryFile(filePath, VM.Kernel);
                
            }
                
        }
    }
}
