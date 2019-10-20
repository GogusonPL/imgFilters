using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ImgFilters.ViewModel.Commands
{
    public class TestCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public ImgFiltersVM VM { get; set; }
        public TestCommand(ImgFiltersVM vm)
        {
            VM = vm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //VM.AfterPhoto = ImgManager.BitmapSourceToByteArray(BradleyFilter.CreateBradley(VM.OriginalPhoto,
            //                                                                         VM.OriginalPhoto.PixelWidth / VM.PrecisionParameter,
            //                                                                         VM.AdjustmentParameter,
            //                                                                         VM.RedParameter, VM.GreenParameter,
            //                                                                         VM.BlueParameter));
            //VM.CurrentPhoto = VM.AfterPhoto;

            //VM.OriginalPhotoCommand.IsLocked = false;
            //VM.OriginalPhotoCommand.OnCanExecuteChanged();
            //VM.AfterPhotoCommand.IsLocked = true;
            //VM.AfterPhotoCommand.OnCanExecuteChanged();
            //VM.AfterPhoto = ImgManager.BitmapSourceToByteArray(GaussFilter.CreateGauss(VM.OriginalPhoto, new Model.Kernel() { LeftBot = 0.5f, LeftMid = 0.5f, LeftTop = 0.5f, Mid = 0.5f, MidBot = 0.5f, MidTop = 0.5f, RightBot = 0.5f, RightMid = 0.5f, RightTop = 0.5f }));
            //VM.CurrentPhoto = VM.AfterPhoto;
            //VM.OriginalPhotoCommand.IsLocked = false;
            //VM.OriginalPhotoCommand.OnCanExecuteChanged();
            //VM.AfterPhotoCommand.IsLocked = true;
            //VM.AfterPhotoCommand.OnCanExecuteChanged(); ;

        }
    }
}
