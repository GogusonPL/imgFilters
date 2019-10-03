using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgFilters.ViewModel
{
    public class BradleyFilter
    {

        //public byte[,] IntegralImage { get; set; }

        //public byte InputImage { get; set; }


        public static byte[,] CreateBinaryImage(byte[,] inputImage, int WIDTH, int HEIGHT, int precision, float adjustment)
        {
            byte[,] binaryImage = new byte[WIDTH, HEIGHT];
            int[,] integralImage = new int[WIDTH, HEIGHT];

            for (int i = 0; i < WIDTH; i++)
            {
                int sum = 0;
                for (int j = 0; j < HEIGHT; j++)
                {
                    sum += inputImage[i, j];
                    if (i == 0)
                    {
                        integralImage[i, j] = sum;
                    }
                    else
                    {
                        integralImage[i, j] = integralImage[i - 1, j] + sum;
                    }


                }
            }

            for (int i = 0; i < WIDTH; i++)
            {
                for (int j = 0; j < HEIGHT; j++)
                {
                    int x1 = i - precision / 2;
                    int x2 = i + precision / 2;
                    int y1 = j - precision / 2;
                    int y2 = j + precision / 2;

                    int count = (x2 - x1) * (y2 - y1);

                    int sum = integralImage[x2, y2] - integralImage[x2, y1 - 1] - integralImage[x1 - 1, y2] + integralImage[x1 - 1, y1 - 1];

                    if((inputImage[i,j]*count) <= (sum*(100 - adjustment) / 100))
                    {
                        binaryImage[i, j] = 0;
                    }
                    else
                    {
                        binaryImage[i, j] = 255;
                    }
                }
            }

            return binaryImage;
        }




    }
}
