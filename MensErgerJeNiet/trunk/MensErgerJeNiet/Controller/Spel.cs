using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MensErgerJeNiet.Model;
using MensErgerJeNiet.Model.Vakken;
using Microsoft.Expression.Shapes;
using MensErgerJeNiet.View;
using System.Windows;
using System.Windows.Media;
using MensErgerJeNiet.Shared;

namespace MensErgerJeNiet.Controller
{
    class Spel
    {
		private Bord _bord;
		private Dobbelsteen _dobbelsteen;
		private Speler[] _spelers;

		private MainWindow _window;

		public Spel()
		{
			_window = new MainWindow();
			_bord = new Bord();
			
			_dobbelsteen = new Dobbelsteen();
			_spelers = new Speler[4];

			for (int i = 0; i < _spelers.Length; i++)
			{
				_spelers[i] = new Speler(_bord.GetStartVak(i), "Speler " + (i + 1));
				SpelerKleur kleur = SpelerKleur.Blauw;

				switch (i)
				{
					case 1: kleur = SpelerKleur.Groen; break;
					case 2: kleur = SpelerKleur.Geel; break;
					case 3: kleur = SpelerKleur.Rood; break;
					default: break; // <- blauw
				}
				_spelers[i].Kleur = kleur;
			}

			AttachView();

			ChangedEventHandler SpelerChangedHandler = new ChangedEventHandler(_window.updateFromSpeler);

			foreach (Speler s in _spelers)
			{
				s.SetPionnen();
				s.Changed += SpelerChangedHandler;
			}

			if (_spelers[0] != null)
			{
				_spelers[0].Status = SpelerStatus.WachtOpDobbelsteen;
			}

			ShowWindow();
		}

		private void ShowWindow()
		{
			_window.Show();
		}

		private void AttachView()
		{
			ChangedEventHandler eventHandler = new ChangedEventHandler(this.updateFromView);
			
			_window.Changed += eventHandler;

			//Vak eersteVak = _bord.EersteVak;
			List<ArcObserver> arcs = _window.Arcs;

			Vak huidigVak = _bord.EersteVak;
			Vak eersteVak = huidigVak;
			int i = 0;

			// heeft huidigVak een volgende? (linkedlist) && volgendvak NIET eerste? Anders zijn we al rond

			while (huidigVak.HeeftVolgende() && huidigVak.Volgende != eersteVak)
			{
				huidigVak.Changed += new ChangedEventHandler(arcs[i].updateFromVak);
				arcs[i].Vak = huidigVak;

				huidigVak = huidigVak.Volgende;
				i++;
			}

			int speler = -1; // Speler index. -1 omdat (0 % 4) == 0
			
			for (int j = 40; j < (40 + 16); j++)
			{
				int modulo = j % 4;

				if (modulo == 0)
				{
					speler++;
				}
				huidigVak = _spelers[speler].GetWachtvak(modulo);
				huidigVak.Changed += new ChangedEventHandler(arcs[j].updateFromVak);
				arcs[j].Vak = huidigVak;
			}
		}

		public void updateFromView(object sender, EventArgs e)
		{
			switch (((EventArgs<ViewEvents>) e).Event)
			{
				case ViewEvents.DiceClick: RollDice(); break;

				case ViewEvents.VakClick:
				{
					Vak value = ((EventArgs<ViewEvents, Vak>) e).Value;
					VakClick(value);

					break;
				}
			}
		}

		private void RollDice()
		{
			_spelers[0].ValueDiced = _dobbelsteen.Gooi();
		}

		private void VakClick(Vak vak)
		{
			if (vak.HeeftPion())
			{
				Pion pion = vak.Pion;
				Speler eigenaar = pion.Eigenaar;

				if (eigenaar.Status == SpelerStatus.WachtOpPion)
				{
					eigenaar.onClickPion(pion);

					if (eigenaar.Status == SpelerStatus.Uit)
					{
						MessageBox.Show("Gewonnen!");
					}
					else if (eigenaar.Status == SpelerStatus.WachtOpBeurt)
					{
						for (int i = 0; i < _spelers.Length - 1; i++)
						{
							Speler speler = _spelers[i];

							if (speler == eigenaar)
							{
								_spelers[(i + 1)].Status = SpelerStatus.WachtOpDobbelsteen;
								// Stop, want we hebben de beurt al doorgegeven
								return;
							}
						}
						// Speler 4 [3] is huidige speler, terug naar 1 [0]
						_spelers[0].Status = SpelerStatus.WachtOpDobbelsteen;
					}
				}
			}
		}
    }
}