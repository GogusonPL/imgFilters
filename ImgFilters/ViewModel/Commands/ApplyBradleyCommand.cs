using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ImgFilters.ViewModel.Commands
{
    public class ApplyBradleyCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        
        public ImgFiltersVM VM { get; set; }
        public ApplyBradleyCommand(ImgFiltersVM vm)
        {
            VM = vm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.AfterPhoto = ImgManager.BitmapSourceToByteArray(BradleyFilter.CreateBradley(VM.OriginalPhoto,
                                                                                     VM.OriginalPhoto.PixelWidth / VM.BradleyParams.PrecisionParameter,
                                                                                     VM.BradleyParams.AdjustmentParameter,
                                                                                     VM.BradleyParams.RedParameter, VM.BradleyParams.GreenParameter,
                                                                                     VM.BradleyParams.BlueParameter));
            VM.CurrentPhoto = VM.AfterPhoto;
            VM.OriginalPhotoCommand.IsLocked = false;
            VM.AfterPhotoCommand.IsLocked = true;
            VM.SavePhotoCommand.OnCanExecuteChanged();

        }
    }
}
