using System;
using System.Drawing;

namespace MyPhotoshop
{
    public static class Convertors
    {
        public static Photo Bitmap2Photo(Bitmap bmp)
        {
            var photo = new Photo(bmp.Width, bmp.Height);
            for (int x = 0; x < bmp.Width; x++)
                for (int y = 0; y < bmp.Height; y++)
                {
                    var color = bmp.GetPixel(x, y);
                    photo.data[x, y].R = (double)color.R / 255;
                    photo.data[x, y].G = (double)color.G / 255;
                    photo.data[x, y].B = (double)color.B / 255;
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

