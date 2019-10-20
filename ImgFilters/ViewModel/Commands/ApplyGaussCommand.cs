using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ImgFilters.ViewModel.Commands
{
    public class ApplyGaussCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public ImgFiltersVM VM { get; set; }
        public ApplyGaussCommand(ImgFiltersVM vm)
        {
            VM = vm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.GaussBuff = GaussFilter.CreateGauss(VM.OriginalPhoto, VM.Kernel);
            VM.AfterPhoto = ImgManager.BitmapSourceToByteArray(VM.GaussBuff);
            VM.CurrentPhoto = VM.AfterPhoto;
            VM.OriginalPhotoCommand.IsLocked = false;
            VM.AfterPhotoCommand.IsLocked = true;
            VM.RepeatGaussCommand.IsLocked = false;



        }
    }
}
