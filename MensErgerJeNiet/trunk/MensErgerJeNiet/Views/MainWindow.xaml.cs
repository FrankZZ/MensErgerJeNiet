using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Expression.Shapes;

namespace WpfApplication1
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private int _arcCount;

		public MainWindow()
		{
			this.InitializeComponent();
			_arcCount = 0;
			// Insert code required on object creation below this point.
		}

		private void Arc_Initialized(object sender, EventArgs e)
		{
			if (_arcCount == 0)
			{
				Arc obj = (Arc)sender;
				obj.ArcThickness = 1;

			}
			i++;
		}
	}
}