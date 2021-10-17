using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public int dotNumber;

		public MainWindow()
		{
			InitializeComponent();
			M_Window.Width = 1000;
			M_Window.Height = 1000;
			canvas.Width = M_Window.Width;
			canvas.Height = M_Window.Height;


			//DrawDot(500, 950);
			//Draw();

		}

		private void DrawDot(double x, double y)
		{
			Ellipse ellipse = new();

			SolidColorBrush color = Brushes.Green;
			ellipse.Width = 1;
			ellipse.Height = 1;
			ellipse.Fill = color;
			Canvas.SetLeft(ellipse, x);
			Canvas.SetTop(ellipse, y);
			canvas.Children.Add(ellipse);
		}

		private void Draw()
		{
			double x0 = 500;
			double y0 = 950;

			var r = new Random();

			double x = 0;
			double y = 0;

			for (int count = 0; count < 20000; count++)
			{
				//DrawDot((int)(300 + 58 * x), (int)(58 * y));
				DrawDot((int)(x0 + 90 * x), (int)(y0 - 90 * y));
				//Thread.Sleep(1);
				int roll = r.Next(100);
				double xp = x;
				if (roll < 1)
				{
					x = 0;
					y = 0.16 * y;
				}
				else if (roll < 86)
				{
					x = 0.85 * x + 0.04 * y;
					y = -0.04 * xp + 0.85 * y + 1.6;
				}
				else if (roll < 93)
				{
					x = 0.2 * x - 0.26 * y;
					y = 0.23 * xp + 0.22 * y + 1.6;
				}
				else
				{
					x = -0.15 * x + 0.28 * y;
					y = 0.26 * xp + 0.24 * y + 0.44;
				}
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			
			Draw();
		}
	}
}
