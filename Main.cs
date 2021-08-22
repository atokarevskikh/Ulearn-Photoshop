using MyPhotoshop.Filters;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyPhotoshop
{
	class MainClass
	{
        [STAThread]
		public static void Main (string[] args)
		{
			var window=new MainWindow();
			window.AddFilter(new PixelFilter<LighteningParameters>(
				"Осветление/затемнение",
				(original, parameters) => original * parameters.Coefficient
			));
			window.AddFilter(new PixelFilter<EmptyParameters>(
				"Оттенки серого",
				(original, parameters) => {
					var lightness = 0.2126 * original.R + 0.7152 * original.G + 0.0722 * original.B;
					return new Pixel(lightness, lightness, lightness);
				}
			));
			//window.AddFilter(new TransformFilter(
			//	"Повернуть на -90 градусов",
			//	size => new Size(size.Height, size.Width),
			//	(point, size) => new Point(size.Width - point.Y - 1, point.X)
			//));
			//window.AddFilter(new TransformFilter(
			//	"Отразить по горизонтали",
			//	size => size,
			//	(point, size) => new Point(size.Width - point.X - 1, point.Y)
			//));

			//Func<Size, RotationParameters, Size> sizeRotator = (size, parameters) =>
			//{
			//	var angle = Math.PI * parameters.Angle / 180;
			//	return new Size(
			//		(int)(size.Width * Math.Abs(Math.Cos(angle)) + size.Height * Math.Abs(Math.Sin(angle))),
			//		(int)(size.Height * Math.Abs(Math.Cos(angle)) + size.Width * Math.Abs(Math.Sin(angle)))
			//	);
			//};

			//Func<Point, Size, RotationParameters, Point?> pointRotator = (point, oldSize, parameters) =>
			//{
			//	var newSize = sizeRotator(oldSize, parameters);
			//	var angle = Math.PI * parameters.Angle / 180;
			//	point = new Point(point.X - newSize.Width / 2, point.Y - newSize.Height / 2);
			//	var x = oldSize.Width / 2 + (int)(point.X * Math.Cos(angle) + point.Y * Math.Sin(angle));
			//	var y = oldSize.Height / 2 + (int)(-point.X * Math.Sin(angle) + point.Y * Math.Cos(angle));
			//	if (x < 0 || x >= oldSize.Width || y < 0 || y >= oldSize.Height) return null;
			//	return new Point(x, y);
			//};

			window.AddFilter(new TransformFilter<RotationParameters>(
				"Свободное вращение",
				new RotateTransformer()
			));

			Application.Run (window);
		}
	}
}
