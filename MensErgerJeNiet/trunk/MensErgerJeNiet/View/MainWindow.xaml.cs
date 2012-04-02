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
using MensErgerJeNiet.View;

namespace MensErgerJeNiet
{

	public partial class MainWindow : Window
	{
		private List<Observer> _arcs;

		public List<Observer> Arcs
		{
			get
			{
				return _arcs;
			}
		}

		public MainWindow()
		{
			_arcs = new List<Observer>();
			this.InitializeComponent();
		}

		private void Arc_Initialized(object sender, EventArgs e)
		{
			Arc arc = (Arc)sender;
			_arcs.Add (new Observer(arc));
		}
	}
}