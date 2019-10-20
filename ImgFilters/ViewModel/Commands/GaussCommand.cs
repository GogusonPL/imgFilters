using System;
using System.Windows;
using System.Windows.Input;

namespace ImgFilters.ViewModel.Commands
{
    public class GaussCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private bool isLocked;
        public bool IsLocked
        {
            get { return isLocked; }
            set
            {
                isLocked = value;
                OnCanExecuteChanged();
            }
        }
        public ImgFiltersVM VM { get; set; }

        public GaussCommand(ImgFiltersVM vm)
        {
            VM = vm;
            IsLocked = true;
            VM.Gauss = Visibility.Visible;
        }

        public bool CanExecute(object parameter)
        {
            if (IsLocked) return false;
            else return true;
        }

        public void Execute(object parameter)
        {
            
            IsLocked = true;
            VM.RepeatGaussCommand.IsLocked = true;
            VM.BradleyCommand.IsLocked = false;
            VM.Bradley = Visibility.Hidden;
            VM.Gauss = Visibility.Visible;
            
            
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