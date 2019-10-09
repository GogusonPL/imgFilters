﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ImgFilters.ViewModel
{
    public static class GaussFilter
    {

        public static BitmapSource CreateGauss(BitmapImage image, int precision, float adjustment, float rParam, float gParam, float bParam)
        {
            int height = image.PixelHeight,
                width = image.PixelWidth;

            int[,] integralImage = new int[height, width];

            int stride = image.PixelWidth * 4;
            int size = image.PixelHeight * stride;
            byte[] outputImagePixels = new byte[size];

            image.CopyPixels(outputImagePixels, stride, 0);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    var x1 = i - precision / 2;
                    if (x1 <= 0) x1 = 1;
                    var x2 = i + precision / 2;
                    if (x2 >= height) x2 = height - 1;
                    var y1 = j - precision / 2;
                    if (y1 <= 0) y1 = 1;
                    var y2 = j + precision / 2;
                    if (y2 >= width) y2 = width - 1;

                    int count = (x2 - x1) * (y2 - y1);

                    int sum = integralImage[x2, y2] - integralImage[x2, y1 - 1] - integralImage[x1 - 1, y2] + integralImage[x1 - 1, y1 - 1];

                    if ((GetGrayScale(stride, outputImagePixels, i, j, rParam, gParam, bParam) * count) <= (sum * (100 - adjustment) / 100))
                    {
                        int index = i * stride + 4 * j;

                        outputImagePixels[index] = 0;
                        outputImagePixels[index + 1] = 0;
                        outputImagePixels[index + 2] = 0;
                    }
                    else
                    {
                        int index = i * stride + 4 * j;

                        outputImagePixels[index] = 255;
                        outputImagePixels[index + 1] = 255;
                        outputImagePixels[index + 2] = 255;
                    }
                }
            }


            return BitmapImage.Create(
                image.PixelWidth,
                image.PixelHeight,
                image.DpiX,
                image.DpiY,
                image.Format,
                image.Palette,
                outputImagePixels,
                stride);
        }

        private static int GetGrayScale(int stride, byte[] pixels, int pixel_height, int pixel_width, float rParam, float gParam, float bParam)
        {
            int index = pixel_height * stride + 4 * pixel_width;

            byte red = pixels[index];
            byte green = pixels[index + 1];
            byte blue = pixels[index + 2];

            //var grayScale = 0.3f * red + 0.6f * green + 0.11f * blue;
            var grayScale = rParam * red + gParam * green + bParam * blue;
            return (int)grayScale;
        }
    }
}

