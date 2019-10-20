using System;
using System.Windows.Input;

namespace ImgFilters.ViewModel.Commands
{
    public class OriginalPhotoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private bool isLocked;

        public bool IsLocked
        {
            get { return isLocked; }
            set { isLocked = value;
                OnCanExecuteChanged();
            }
        }

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
            VM.AfterPhotoCommand.IsLocked = false;

            
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