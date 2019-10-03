using System;
using System.Windows.Input;

namespace ImgFilters.ViewModel.Commands
{
    public class SelectPhotoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public ImgFiltersVM VM { get; set; }

        public SelectPhotoCommand(ImgFiltersVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            // ALWAYS ENABLED
            return true;
        }

        public void Execute(object parameter)
        {
            VM.SelectImage();
        }
    }
}