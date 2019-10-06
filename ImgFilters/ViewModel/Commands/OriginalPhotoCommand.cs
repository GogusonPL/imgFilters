using System;
using System.Windows.Input;

namespace ImgFilters.ViewModel.Commands
{
    public class OriginalPhotoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public bool IsLocked { get; set; }
        public ImgFiltersVM VM { get; set; }

        public OriginalPhotoCommand(ImgFiltersVM vm)
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
            VM.CurrentPhoto = ImgManager.BitmapSourceToByteArray(VM.OriginalPhoto);
            VM.OriginalPhotoCommand.IsLocked = true;
            VM.OriginalPhotoCommand.OnCanExecuteChanged();
            VM.AfterPhotoCommand.IsLocked = false;
            VM.AfterPhotoCommand.OnCanExecuteChanged();
            
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