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
                {
                    var lightness = 0.2126 * original[x, y].R + 0.7152 * original[x, y].G + 0.0722 * original[x, y].B;
                    result[x, y] = new Pixel(lightness, lightness, lightness);
                }
                    
            return result;
        }
    }
}

