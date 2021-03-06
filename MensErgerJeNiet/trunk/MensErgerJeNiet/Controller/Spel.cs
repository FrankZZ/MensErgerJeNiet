﻿using System;
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

		private ChangedEventHandler changedHandler;

		private int _speler;

		private MainWindow _window;

		public Spel()
		{
			changedHandler = new ChangedEventHandler(updateFromView);

			StartView startView = new StartView();
			startView.Changed += changedHandler;

		}

		private void start(int spelers)
		{
			_speler = 0;
			_bord = new Bord();

			_dobbelsteen = new Dobbelsteen();
			
			_spelers = new Speler[spelers];

			for (int i = 0; i < _spelers.Length; i++)
			{
				_spelers[i] = new Speler(_bord.GetStartVak(i), _bord.GetWachtvak(i), _dobbelsteen, "Speler " + (i + 1));

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

			_window = new MainWindow(_bord);
			_window.Changed += changedHandler;

			ChangedEventHandler SpelerChangedHandler = new ChangedEventHandler(_window.updateFromSpeler);

			foreach (Speler s in _spelers)
			{
				s.SetPionnen();
				s.Changed += SpelerChangedHandler;
			}

			// Speler 1 status op WachtOpDobbelsteen zetten.
			if (_spelers[0] != null)
			{
				_spelers[0].Status = SpelerStatus.WachtOpDobbelsteen;
			}
		}

		public void updateFromView(object sender, EventArgs e)
		{
			switch (((EventArgs<ViewEvents>) e).Event)
			{
				case ViewEvents.DiceClick: 
				{
					if (e is EventArgs<ViewEvents, int>)
					{
						_spelers[_speler].ValueDiced = ((EventArgs<ViewEvents, int>) e).Value;
					}
					else
						RollDice();
					break;
				}

				case ViewEvents.VakClick:
				{
					Vak value = ((EventArgs<ViewEvents, Vak>) e).Value;
					VakClick(value);

					break;
				}

				case ViewEvents.TextClick:
				{
					DumpText();
					break;
				}

				case ViewEvents.StartClick:
				{
					if (e is EventArgs<ViewEvents, int>)
					{
						EventArgs<ViewEvents, int> ev = (EventArgs<ViewEvents, int>) e;
						start(ev.Value);
					}
					break;
				}
			}
		}

		private void RollDice()
		{
			_spelers[_speler].RollDice();
		}

		private void DumpText()
		{
			new TextView(_bord);
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
							_speler = _speler % _spelers.Length;
						}
					}
				}
			}
		}
    }
}