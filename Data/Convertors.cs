using System;
using System.Drawing;

namespace MyPhotoshop
{
    public static class Convertors
    {
        public static Photo Bitmap2Photo(Bitmap bmp)
        {
            var photo = new Photo();
            photo.width = bmp.Width;
            photo.height = bmp.Height;
            photo.data = new Pixel[bmp.Width, bmp.Height];
            for (int x = 0; x < bmp.Width; x++)
                for (int y = 0; y < bmp.Height; y++)
                {
                    var color = bmp.GetPixel(x, y);
                    var pixel = new Pixel((double)color.R / 255, (double)color.G / 255, (double)color.G / 255);
                    photo.data[x, y] = pixel;
                }
            return photo;
        }

        static int ToChannel(double val)
        {
            return (int)(val * 255);
        }

        public static Bitmap Photo2Bitmap(Photo photo)
        {
            var bmp = new Bitmap(photo.width, photo.height);
            for (int x = 0; x < bmp.Width; x++)
                for (int y = 0; y < bmp.Height; y++)
                    bmp.SetPixel(x, y, Color.FromArgb(
                        ToChannel(photo.data[x, y].R),
                        ToChannel(photo.data[x, y].G),
                        ToChannel(photo.data[x, y].B)));

            return bmp;
        }
    }
}

