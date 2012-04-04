using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MensErgerJeNiet.Model.Vakken;
using System.Windows;

namespace MensErgerJeNiet.Model
{
	public class Bord
	{
		private Vak _eerstevak;
		private Beginvak[] _startvakken;

		public Vak EersteVak
		{
			get
			{
				return _eerstevak;
			}
		}

		public Beginvak GetStartVak(int positie)
		{
			if (positie >= 0 && positie < _startvakken.Length)
			{
				return _startvakken[positie];
			}
			return null;
		}

		public Bord()
		{
			int speler = 0;
			_startvakken = new Beginvak[4];

			// Eerste vakje alvast maken vóór de loop
			_eerstevak = new Beginvak();
			_startvakken[speler++] = (Beginvak)_eerstevak;

			// eerste vak is in dit geval de vorige voor de loop
			Vak huidigVak = _eerstevak;
			Vak vorigVak = _eerstevak;

			// i = 1 omdat het startvakje hierboven al gemaakt is
			for (int i = 1; i < 40; i++) // i = 1 omdat het startvakje hierboven al gemaakt is
			{

				int modulo = i % 10;

				if (modulo == 0) // Startvakje
				{
					huidigVak = new Beginvak();
					_startvakken[speler++] = (Beginvak) huidigVak;
				}
				else
				{
					huidigVak = new Speelvak();

					if (modulo == 9) // Koppelvakje
					{
						// TODO: Extra methodes voor koppelvak
					}
				}
				// Koppel vorige vak aan huidige, linked list
				vorigVak.Volgende = huidigVak;

				vorigVak = huidigVak;
			}

			// koppel de laatste aan de eerste, zodat pionnen ROND kunnen lopen
			huidigVak.Volgende = _eerstevak;
		}
	}
}