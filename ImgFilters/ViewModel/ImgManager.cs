using System.IO;
using System.Windows.Media.Imaging;

namespace ImgFilters.ViewModel
{
    public static class ImgManager
    {
        public static byte[] BitmapSourceToByteArray(BitmapSource bitmapImage)
        {
            byte[] data;
            var encoder = new PngBitmapEncoder();

            encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }

            return data;
        }

 

    }
}