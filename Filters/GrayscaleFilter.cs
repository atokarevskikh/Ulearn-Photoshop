using System;

namespace MyPhotoshop
{
    public class GrayscaleFilter : PixelFilter<EmptyParameters>
    {
        public override string ToString()
        {
            return "Оттенки серого";
        }

        public override Pixel ProcessPixel(Pixel original, EmptyParameters parameters)
        {
            var lightness = 0.2126 * original.R + 0.7152 * original.G + 0.0722 * original.B;
            return new Pixel(lightness, lightness, lightness);
        }
    }
}

