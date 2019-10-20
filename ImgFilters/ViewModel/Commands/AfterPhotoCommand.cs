using System;
using System.Windows.Input;

namespace ImgFilters.ViewModel.Commands
{
    public class AfterPhotoCommand : ICommand
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

        public AfterPhotoCommand(ImgFiltersVM vm)
        {
            VM = vm;
            IsLocked = true;
        }

        public bool CanExecute(object parameter)
        {
            if (IsLocked) return false;
            else return true;
        }

        public void Execute(object parameter)
        {
            VM.CurrentPhoto = VM.AfterPhoto;
            VM.AfterPhotoCommand.IsLocked = true;
            VM.OriginalPhotoCommand.IsLocked = false;

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