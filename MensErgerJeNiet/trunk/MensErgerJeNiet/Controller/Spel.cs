using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MensErgerJeNiet.Model;
using MensErgerJeNiet.Model.Vakken;
using Microsoft.Expression.Shapes;
using MensErgerJeNiet.View;
using System.Windows;

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
			
			AttachView();

			_dobbelsteen = new Dobbelsteen();
			_spelers = new Speler[4];

			for (int i = 0; i < _spelers.Length; i++)
			{
				_spelers[i] = new Speler(_bord.GetStartVak(i));
			}
			ShowWindow();
		}

		private void ShowWindow()
		{
			_window.Show();
		}

		private void AttachView()
		{
			//Vak eersteVak = _bord.EersteVak;
			List<ArcObserver> arcs = _window.Arcs;

			Vak huidigVak = _bord.EersteVak;
			Vak eersteVak = huidigVak;
			int i = 0;

			// heeft huidigVak een volgende? (linkedlist) && volgendvak NIET eerste? Anders zijn we al rond

			while (huidigVak.HeeftVolgende() && huidigVak.Volgende != eersteVak)
			{
				huidigVak.Changed += new ChangedEventHandler(arcs[i].update);

				huidigVak = huidigVak.Volgende;
				i++;
			}
			MessageBox.Show(i.ToString());
		}
    }
}