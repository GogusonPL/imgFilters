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
            return true;
        }

        public void Execute(object parameter)
        {

            VM.Test = ImgManager.BitmapSourceToByteArray(BradleyFilter.CreateBradley(VM.UploadedPhoto,
                                                                                     VM.UploadedPhoto.PixelWidth / VM.PrecisionParameter,
                                                                                     VM.AdjustmentParameter,
                                                                                     VM.RedParameter, VM.GreenParameter,
                                                                                     VM.BlueParameter));
            
        }
    }
}