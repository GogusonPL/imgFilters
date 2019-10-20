using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace ImgFilters.ViewModel.Commands
{
    public class RepeatGaussCommand : ICommand
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
        public RepeatGaussCommand(ImgFiltersVM vm)
        {
            VM = vm;
        }
        public bool CanExecute(object parameter)
        {
            if (VM.AfterPhoto != null && VM.GaussCommand.IsLocked == true && IsLocked == false) return true;
            else
                return false;

        }

        public void Execute(object parameter)
        {
            VM.GaussBuff = GaussFilter.CreateGauss(VM.GaussBuff, VM.Kernel);
            VM.AfterPhoto = ImgManager.BitmapSourceToByteArray(VM.GaussBuff);
            VM.CurrentPhoto = VM.AfterPhoto;
            VM.OriginalPhotoCommand.IsLocked = false;
            VM.AfterPhotoCommand.IsLocked = true;

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
