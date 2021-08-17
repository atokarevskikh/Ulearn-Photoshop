using System;

namespace MyPhotoshop
{
    public class GrayscaleFilter : IFilter
    {
        public ParameterInfo[] GetParameters()
        {
            return new ParameterInfo[0];

        }

        public override string ToString()
        {
            return "Оттенки серого";
        }

        public Photo Process(Photo original, double[] parameters)
        {
            var result = new Photo(original.width, original.height);
            for (int x = 0; x < result.width; x++)
                for (int y = 0; y < result.height; y++)
                    result[x, y] = ProcessPixel(original[x, y], null);
            return result;
        }

        public Pixel ProcessPixel(Pixel original, double[] parameters)
        {
            var lightness = 0.2126 * original.R + 0.7152 * original.G + 0.0722 * original.B;
            return new Pixel(lightness, lightness, lightness);
        }
    }
}

