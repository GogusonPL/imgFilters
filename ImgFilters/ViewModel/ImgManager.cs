using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ImgFilters.ViewModel
{
    public class ImgManager
    {
        public static byte[] BitmapImageToByteArray(BitmapImage bitmapImage)
        {
            byte[] data;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }

            return data;
        }
       
        public static BitmapImage ByteArrayToBitmapImage(byte[] array)
        {
            
                using (var ms = new System.IO.MemoryStream(array))
                {
                    var image = new BitmapImage();
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad; 
                    image.StreamSource = ms;
                    image.EndInit();
                    return image;
                }
            
        }

        public static byte[,] Create2DArrayFrom1DArray(byte[] inputArray, int WIDHT, int HEIGHT)
        {
            byte[,] output = new byte[HEIGHT, WIDHT];
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDHT; j++)
                {
                    output[i, j] = inputArray[i * WIDHT + j];
                }
            }
            return output;
        }

        public static byte[] Create1DArrayFrom2DArray(byte[,] input)
        {
            int WIDTH = input.GetLength(0), HEIGHT = input.GetLength(1);
            byte[] output = new byte[WIDTH*HEIGHT];
            int counter = 0;
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    output[WIDTH * i + j] = input[i,j];
                }
            }
            
            return output;
        }






    }
}
