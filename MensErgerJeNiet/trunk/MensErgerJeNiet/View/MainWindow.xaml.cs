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

namespace MensErgerJeNiet
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private int _arcCount;
		private List<Arc> _arcs;

		public MainWindow()
		{
			_arcs = new List<Arc>();
			this.InitializeComponent();
			_arcCount = 0;
		}

		private void Arc_Initialized(object sender, EventArgs e)
		{
			if (_arcCount == 1)
			{
				Arc arc = (Arc)sender;
				_arcs.Add(arc);
			}
			_arcCount++;
		}
	}
}