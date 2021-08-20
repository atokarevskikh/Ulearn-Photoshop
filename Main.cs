using System;
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
			Application.Run (window);
		}
	}
}
