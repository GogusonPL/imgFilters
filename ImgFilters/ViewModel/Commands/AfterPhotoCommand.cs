using System;
using System.Windows.Input;

namespace ImgFilters.ViewModel.Commands
{
    public class AfterPhotoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public bool IsLocked { get; set; }
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
            VM.AfterPhotoCommand.OnCanExecuteChanged();
            VM.OriginalPhotoCommand.IsLocked = false;
            VM.OriginalPhotoCommand.OnCanExecuteChanged();
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