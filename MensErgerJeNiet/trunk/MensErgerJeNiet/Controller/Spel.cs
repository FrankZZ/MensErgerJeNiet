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
				_spelers[i] = new Speler(_bord.GetStartVak(i));
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

			ShowWindow();

			foreach (Speler s in _spelers)
			{
				s.SetPionnen();
			}
		}

		private void ShowWindow()
		{
			_window.Show();
		}

		private void AttachView()
		{
			_window.Changed += new ChangedEventHandler(this.updateFromView);

			//Vak eersteVak = _bord.EersteVak;
			List<Observer> arcs = _window.Arcs;

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

			// Speler koppelen aan
			_spelers[speler].Changed += new ChangedEventHandler(_window.updateFromSpeler);
		}

		public void updateFromView(object sender, EventArgs e)
		{
			int waarde = _dobbelsteen.Gooi();

			_spelers[0].doTurn(waarde);
		}
    }
}