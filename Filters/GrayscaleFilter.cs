using System;

namespace MyPhotoshop
{
    public class GrayscaleFilter : PixelFilter
    {
        public override  ParameterInfo[] GetParameters()
        {
            return new ParameterInfo[0];
        }

        public override string ToString()
        {
            return "Оттенки серого";
        }

        public override Pixel ProcessPixel(Pixel original, double[] parameters)
        {
            var lightness = 0.2126 * original.R + 0.7152 * original.G + 0.0722 * original.B;
            return new Pixel(lightness, lightness, lightness);
        }
    }
}

