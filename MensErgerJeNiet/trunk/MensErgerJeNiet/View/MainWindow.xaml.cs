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

		private List<Arc> _arcs;
		private Dictionary<Arc, ArcObserver> _observers;

		public MainWindow(Bord bord)
		{
			_model = bord;
			_observers = new Dictionary<Arc, ArcObserver>();
			_arcs = new List<Arc>();

			this.InitializeComponent();

			Attach();
		}

		private void Attach()
		{
			int i = 0;
			int speler = 0;

			Vak beginVak = _model.EersteVak;
			
			AttachObserverToVak(_observers[_arcs[i]], beginVak);
			i++;
			speler++;

			Vak huidigVak = beginVak.Volgende;
			Eindvak[] eindVakken = new Eindvak[4];

			// Regulier veld, het kruis
			while (huidigVak != beginVak && huidigVak.HeeftVolgende() && i < _arcs.Count)
			{
				AttachObserverToVak(_observers[_arcs[i]], huidigVak);

				if (huidigVak is Koppelvak)
				{
					Koppelvak koppelVak = (Koppelvak) huidigVak;
					if (koppelVak.HeeftEindvak())
					{
						Eindvak eindVak = (Eindvak) koppelVak.Eindvak;
						//ArcObserver arc = _observers[_arcs[
						
						int j = 0;

						while (j < 4)
						{
							int idx = 56 + j + (speler * 4);
							ArcObserver arc = _observers[_arcs[idx]];
							
							AttachObserverToVak(arc, eindVak);

							if (eindVak.HeeftVolgende())
								eindVak = (Eindvak) eindVak.Volgende;

							j++;
						}
					}
					//MessageBox.Show(speler.ToString());
					Wachtvak wachtVak = _model.GetWachtvak(speler);

					int n = 0;

					while (n < 4)
					{
						//MessageBox.Show("WACHT " + n.ToString());
						int idx = 40 + n + (speler * 4);
						ArcObserver arc = _observers[_arcs[idx]];

						AttachObserverToVak(arc, wachtVak);

						if (wachtVak.HeeftVolgendeWachtvak())
							wachtVak = (Wachtvak)wachtVak.VolgendeWachtvak;

						n++;
					}

				}
				
				if (i % 10 == 0)
				{
					speler = ++speler % 4;
				}

				huidigVak = huidigVak.Volgende;
				i++;
			}
		}

		private void AttachObserverToVak(ArcObserver arc, Vak vak)
		{
			vak.Changed += new ChangedEventHandler(arc.updateFromVak);
			arc.Vak = vak;
		}

		private void Arc_Initialized(object sender, EventArgs e)
		{
			Arc arc = (Arc)sender;
			ArcObserver observer = new ArcObserver(arc);
			
			_arcs.Add(arc);
			_observers.Add(arc, observer);
		}

		private void Arc_MouseDown(object sender, MouseButtonEventArgs e)
		{
			OnChanged(ViewEvents.VakClick, _observers[(Arc)sender].Vak);
		}

		private void DiceButton_Click(object sender, RoutedEventArgs e)
		{
			if (diceCheat.Text.Length > 0)
			{
				OnChanged(ViewEvents.DiceClick, Convert.ToInt32(diceCheat.Text));
			}
			else
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

		private void OnChanged(ViewEvents evt, int cheat)
		{
			if (Changed != null)
			{
				Changed(this, new EventArgs<ViewEvents, int>(evt, cheat));
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

		private void TextViewButton_Click(object sender, RoutedEventArgs e)
		{
			// Todo
		}
	}
}