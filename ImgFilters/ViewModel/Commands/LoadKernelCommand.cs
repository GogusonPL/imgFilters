using ImgFilters.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ImgFilters.ViewModel.Commands
{
    public class LoadKernelCommand : ICommand
    {
        //TODO: add in vm
        public event EventHandler CanExecuteChanged;
        public ImgFiltersVM VM { get; set; }
        public LoadKernelCommand(ImgFiltersVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            OpenFileDialog dialog_window = new OpenFileDialog();
            if (dialog_window.ShowDialog() == true)
            {
                VM.Kernel = FileManager.ReadFromBinaryFile<Kernel>(dialog_window.FileName);
               
            }
        }
    }
}
