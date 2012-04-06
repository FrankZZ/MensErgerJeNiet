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
using MensErgerJeNiet.Model.Vakken;

namespace MensErgerJeNiet
{

	public partial class MainWindow : Window
	{
		private List<ArcObserver> _arcs;
		private Dictionary<Arc,ArcObserver> _observers;
		
		public ChangedEventHandler Changed;

		public List<ArcObserver> Arcs
		{
			get
			{
				return _arcs;
			}
		}

		public MainWindow()
		{
			_arcs = new List<ArcObserver>();
			_observers = new Dictionary<Arc, ArcObserver>();

			this.InitializeComponent();
		}

		private void Arc_Initialized(object sender, EventArgs e)
		{
			Arc arc = (Arc)sender;
			ArcObserver observer = new ArcObserver(arc);

			_arcs.Add (observer);
			_observers.Add(arc, observer);
		}

		private void Arc_MouseDown(object sender, MouseButtonEventArgs e)
		{
			OnChanged(ViewEvents.VakClick, _observers[(Arc)sender].Vak);
		}

		private void DiceButton_Click(object sender, RoutedEventArgs e)
		{
			OnChanged(ViewEvents.DiceClick);
		}

		private void OnChanged(ViewEvents evt)
		{
			if (Changed != null)
			{
				Changed(this, new EventArgs<ViewEvents>(evt));
			}
		}

		private void OnChanged(ViewEvents evt, Vak vak)
		{
			if (Changed != null)
			{
				Changed(this, new EventArgs<ViewEvents, Vak>(evt, vak));
			}
		}

		public void updateFromSpeler(object sender, EventArgs e)
		{
			Speler speler = (Speler)sender;

			if (speler.Status == SpelerStatus.WachtOpDobbelsteen)
			{

			}

			if (speler.Status == SpelerStatus.WachtOpPion)
			{
				txtStatus.Text = "Kies één van uw pionnen om " + speler.ValueDiced + " plekken te verzetten.";
			}
			MessageBox.Show(speler.ToString() + ": " + speler.Status.ToString());
		}
	}
}