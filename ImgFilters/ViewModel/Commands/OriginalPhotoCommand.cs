using System;
using System.Windows.Input;

namespace ImgFilters.ViewModel.Commands
{
    public class OriginalPhotoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public ImgFiltersVM VM { get; set; }

        public OriginalPhotoCommand(ImgFiltersVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return false;
        }

        public void Execute(object parameter)
        {
        }
    }
}