﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MensErgerJeNiet.Model;

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
			_bord = new Bord();
			_dobbelsteen = new Dobbelsteen();
			_spelers = new Speler[4];

			for (int i = 0; i < _spelers.Length; i++)
			{
				_spelers[i] = new Speler();

				_spelers[i].Beginvak = _bord.GetStartVak(i);
			}
			ShowWindow();
		}

		private void ShowWindow()
		{
			_window = new MainWindow();
			_window.Show();
		}

		private void AttachView()
		{
			for (int i = 0; i<
			new ChangedEventHandler(.update);
		}
    }
}