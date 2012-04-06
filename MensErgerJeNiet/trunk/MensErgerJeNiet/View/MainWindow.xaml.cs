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
using MensErgerJeNiet.Shared;
using MensErgerJeNiet.Model;

namespace MensErgerJeNiet
{

	public partial class MainWindow : Window
	{
		private List<Observer> _arcs;
		private Dictionary<Arc,Observer> _observers;
		
		public ChangedEventHandler Changed;

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
			_observers = new Dictionary<Arc, Observer>();

			this.InitializeComponent();
		}

		private void Arc_Initialized(object sender, EventArgs e)
		{
			Arc arc = (Arc)sender;
			Observer observer = new Observer(arc);

			_arcs.Add (observer);
			_observers.Add(arc, observer);
		}

		private void Arc_MouseDown(object sender, MouseButtonEventArgs e)
		{
			_observers[(Arc)sender].OnClick();
		}

		private void DiceButton_Click(object sender, RoutedEventArgs e)
		{
			OnChanged();
		}

		private void OnChanged()
		{
			if (Changed != null)
			{
				Changed(this, new EventArgs());
			}
		}

		public void updateFromSpeler(object sender, EventArgs e)
		{

			MessageBox.Show(((Speler) sender)..ToString());
		}
	}
}