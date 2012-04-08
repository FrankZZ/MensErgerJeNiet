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
using MensErgerJeNiet.Controller;

namespace MensErgerJeNiet
{

	public partial class MainWindow : Window
	{
		public ChangedEventHandler Changed;
		
		private Bord _model;

		private Dictionary<Arc, ArcObserver> _observers;

		public MainWindow(Bord bord)
		{
			_model = bord;
			_observers = new Dictionary<Arc, ArcObserver>();

			this.InitializeComponent();
		}

		private void Arc_Initialized(object sender, EventArgs e)
		{
			Arc arc = (Arc)sender;
			ArcObserver observer = new ArcObserver(arc);
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
				DiceButton.IsEnabled = true;
				lblDice.Content = "";
				txtStatus.Text = "Gooi met de dobbelsteen";
				lblCurrPlayer.Content = speler.ToString();
			}

			if (speler.Status == SpelerStatus.WachtOpPion)
			{
				DiceButton.IsEnabled = false;
				txtStatus.Text = "Kies welke van uw pionnen u " + speler.ValueDiced + " plaats" + (speler.ValueDiced > 1 ? "en" : "") + " wilt verzetten";
				lblDice.Content = speler.ValueDiced;
			}
			//MessageBox.Show(speler.ToString() + ": " + speler.Status.ToString());
		}
	}
}