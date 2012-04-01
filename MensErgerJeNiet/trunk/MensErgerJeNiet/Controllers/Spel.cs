using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MensErgerJeNiet.Models;

namespace MensErgerJeNiet.Controller
{
    class Spel
    {
		private Bord _bord;
		private Dobbelsteen _dobbelsteen;
		private Speler[] _spelers;

		public Spel()
		{
			_bord = new Bord();
			_dobbelsteen = new Dobbelsteen();
			_spelers = new Speler[4];


		}
    }
}