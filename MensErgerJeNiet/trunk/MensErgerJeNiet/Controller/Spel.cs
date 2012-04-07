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

		private int _speler;

		private MainWindow _window;

		public Spel()
		{
			_speler = 0;
			_window = new MainWindow();
			_bord = new Bord();
			
			_dobbelsteen = new Dobbelsteen();
			_spelers = new Speler[4];

			for (int i = 0; i < _spelers.Length; i++)
			{
				_spelers[i] = new Speler(_bord.GetStartVak(i), "Speler " + (i + 1));
				
				if (i > 0)
				{
					_spelers[i - 1].Volgende = _spelers[i];
				}

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
			// laatste met eerste verbinden
			_spelers[_spelers.Length - 1].Volgende = _spelers[0];

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
			int eindVakCount = 55;

			// heeft huidigVak een volgende? (linkedlist) && volgendvak NIET eerste? Anders zijn we al rond

			while (huidigVak.HeeftVolgende() && huidigVak.Volgende != eersteVak)
			{
				if (huidigVak is Koppelvak)
				{
					Eindvak huidigEindvak = ((Koppelvak)huidigVak).Eindvak;

					for (int j = 1; j <= 4; j++)
					{
						int idx = eindVakCount + j;
						huidigEindvak.Changed += new ChangedEventHandler(arcs[idx].updateFromVak);
						
						arcs[idx].Vak = huidigEindvak;
						
						huidigEindvak = (Eindvak) huidigEindvak.Volgende;
					}
					eindVakCount += 4;
				}

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
			_spelers[_speler].ValueDiced = _dobbelsteen.Gooi();
			//_spelers[_speler].ValueDiced = 41;
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
						Speler speler = eigenaar;
						int countSpelers = 0;
						while (speler.Volgende != eigenaar)
						{
							countSpelers++;
							if (speler.Volgende.Status != SpelerStatus.Uit)
							{
								speler.Volgende.Status = SpelerStatus.WachtOpDobbelsteen;
								break;
							}
							speler = speler.Volgende;
						}
						if (speler.Volgende.Status == SpelerStatus.Uit)
							MessageBox.Show(eigenaar.ToString() + " is als laatste over!");
						else
						{
							_speler += countSpelers;
							_speler = _speler % 4;
						}

					}
				}
			}
		}
    }
}