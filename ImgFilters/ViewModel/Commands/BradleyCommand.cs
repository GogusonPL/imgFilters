using System;
using System.Windows.Input;

namespace ImgFilters.ViewModel.Commands
{
    public class BradleyCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public ImgFiltersVM VM { get; set; }

        public BradleyCommand(ImgFiltersVM vm)
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