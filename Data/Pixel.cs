using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public class Pixel
    {
        private double r;
        private double g;
        private double b;

        public Pixel(double r, double g, double b)
        {
            R = r;
            G = g;
            B = b;
        }

        public double R
        {
            get => r;
            private set => r = Check(value);
        }

        public double G
        {
            get => g;
            private set => g = Check(value);
        }

        public double B
        {
            get => b;
            private set => b = Check(value);
        }

        private double Check(double value)
        {
            if (value < 0 || value > 1)
                throw new ArgumentException(string.Format("Wrong channel value {0} (the value must be between 0 and 1", value));
            return value;
        }
    }
}
