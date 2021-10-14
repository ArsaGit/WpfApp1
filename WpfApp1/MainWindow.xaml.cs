using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
		public MainWindow()
		{
			InitializeComponent();

			var alpha = 2;
			var beta = 80;
			var k = 0.12;
			var k1 = 0.3;
			Dictionary<char,double> settings = GetConfig(alpha, beta, k, k1);


			SetGrid();
			Draw(grid1, M_Window.Width - 100, M_Window.Height / 2 + 100, 50, 200, 0, settings);
		}

		private Dictionary<char, double> GetConfig(int alpha, int beta, double k, double k1)
		{
			var config = new Dictionary<char, double>();
			config.Add('A', Math.Cos(Convert.ToDouble(alpha) * Math.PI / 180d));
			config.Add('B', Math.Cos(Convert.ToDouble(alpha) * Math.PI / 180d));
			config.Add('C', 1d - k);
			config.Add('D', k);
			config.Add('E', 1d - k1);
			config.Add('F', k1);
			config.Add('G', Math.Cos(Convert.ToDouble(beta) * Math.PI / 180d));
			config.Add('H', Math.Cos(Convert.ToDouble(beta) * Math.PI / 180d));
			return config;
		}

		private void SetGrid()
		{
			grid1.Height = M_Window.Height;
			grid1.Width = M_Window.Width;
		}

		private void Draw(Grid grid, double x1, double y1, double x2, double y2, double num, Dictionary<char, double> settings)
		{
			if (num < 3)
			{
				if ((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2) > 1)
				{
					var x3 = (x2 - x1) * settings['A'] - (y2 - y1) * settings['B'] + x1;
					var y3 = (x2 - x1) * settings['B'] + (y2 - y1) * settings['A'] + y1;
					var x4 = x1 * settings['C'] + x3 * settings['D'];
					var y4 = y1 * settings['C'] + y3 * settings['D'];
					var x5 = x4 * settings['E'] + x3 * settings['F'];
					var y5 = y4 * settings['E'] + y3 * settings['F'];
					var x6 = (x5 - x4) * settings['G'] - (y5 - y4) * settings['H'] + x4;
					var y6 = (x5 - x4) * settings['H'] + (y5 - y4) * settings['G'] + y4;
					var x7 = (x5 - x4) * settings['G'] + (y5 - y4) * settings['H'] + x4;
					var y7 = -(x5 - x4) * settings['H'] + (y5 - y4) * settings['G'] + y4;
					Line line = new Line();
					line.Stroke = Brushes.Green;
					line.StrokeThickness = 2;
					line.X1 = x1;
					line.Y1 = y1;
					line.X2 = x4;
					line.Y2 = y4;
					grid1.Children.Add(line);
					Draw(grid, x4, y4, x3, y3, num + 1, settings);
					Draw(grid, x4, y4, x6, y6, num + 1, settings);
					Draw(grid, x4, y4, x7, y7, num + 1, settings);
				}
			}
		}
	}
}
