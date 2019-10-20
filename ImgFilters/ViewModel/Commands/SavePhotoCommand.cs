using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace ImgFilters.ViewModel.Commands
{
    public class SavePhotoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public ImgFiltersVM VM { get; set; }
        public SavePhotoCommand(ImgFiltersVM vm)
        {
            VM = vm;
        }
        public bool CanExecute(object parameter)
        {
            if (VM.AfterPhoto != null) return true;
            else
                return false;
        }

        public void Execute(object parameter)
        {
            SaveFileDialog dialog_window = new SaveFileDialog();
            dialog_window.Filter = "Png Image (.png)|*.png";
            dialog_window.FilterIndex = 0;
            dialog_window.DefaultExt = "png";
            if (dialog_window.ShowDialog() == true)
            {
                string filePath = dialog_window.FileName;

                var image = ImgManager.ByteArrayToBitmapImage(VM.AfterPhoto);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        BitmapEncoder encoder = new PngBitmapEncoder();
                        encoder.Frames.Add(BitmapFrame.Create(image));
                        encoder.Save(fileStream);
                    }
                

            }
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
