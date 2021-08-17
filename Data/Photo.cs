using System;

namespace MyPhotoshop
{
	public class Photo
	{
		public readonly int width;
		public readonly int height;

		private readonly Pixel[,] data;

		public Pixel this[int x, int y] => data[x, y];

		public Photo(int width, int height)
        {
			this.width = width;
			this.height = height;
			data = new Pixel[width, height];
			for (int i = 0; i < width; i++)
				for (int j = 0; j < height; j++)
					data[i, j] = new Pixel();
        }
    }
}

