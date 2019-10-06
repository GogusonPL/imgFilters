using ImgFilters.View;
using System;
using System.Windows;
using System.Windows.Input;

namespace ImgFilters.ViewModel.Commands
{
    public class BradleyCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public bool IsLocked { get; set; }
        public ImgFiltersVM VM { get; set; }

        public BradleyCommand(ImgFiltersVM vm)
        {
            VM = vm;
            IsLocked = false;
            VM.BradleyUCVisibility = Visibility.Hidden;
        }

        public bool CanExecute(object parameter)
        {
            if (IsLocked) return false;
            else return true;
        }

        public void Execute(object parameter)
        {

            IsLocked = true;
            VM.GaussCommand.IsLocked = false;
            //TODO: gaus visibility
            VM.BradleyUCVisibility = Visibility.Visible;
            OnCanExecuteChanged();
            VM.GaussCommand.OnCanExecuteChanged();

        }
        public void OnCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, new EventArgs());
            }
        }
    }
}