using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MensErgerJeNiet.Model.Vakken;
using System.Windows;
using MensErgerJeNiet.Shared;

namespace MensErgerJeNiet.Model
{
	public class Bord
	{
		private Vak _eerstevak;
		private Beginvak[] _startvakken;
		private Wachtvak[] _wachtvakken;


		public Vak EersteVak
		{
			get
			{
				return _eerstevak;
			}
		}

		public Wachtvak GetWachtvak(int positie)
		{
			if (positie >= 0 && positie < _wachtvakken.Length)
			{
				return _wachtvakken[positie];
			}
			return null;
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

			_wachtvakken = new Wachtvak[4];

			// Eerste vakje alvast maken vóór de loop
			_eerstevak = new Koppelvak();

			// eerste vak is in dit geval de vorige voor de loop
			Vak huidigVak = _eerstevak;
			Vak vorigVak = _eerstevak;

			// i = 1 omdat het startvakje hierboven al gemaakt is
			for (int i = 0; i < 40; i++) // i = 1 omdat het startvakje hierboven al gemaakt is
			{

				int modulo = (i - 1) % 10;

				if (modulo == 0) // Startvakje
				{
					huidigVak = new Beginvak();
					_startvakken[speler] = (Beginvak)huidigVak;

					Eindvak nieuwVak = new Eindvak();
					((Koppelvak)vorigVak).Eindvak = nieuwVak;

					for (int j = 0; j < 4; j++)
					{
						Eindvak oudVak = nieuwVak;

						nieuwVak = new Eindvak();

						oudVak.Volgende = nieuwVak;
					}

					Wachtvak wachtVak = new Wachtvak();

					wachtVak.Volgende = huidigVak;

					_wachtvakken[speler] = wachtVak;

					for (int j = 0; j < 4; j++)
					{
						wachtVak.VolgendeWachtvak = new Wachtvak();

						wachtVak.Volgende = _startvakken[speler];

						wachtVak = (Wachtvak)wachtVak.VolgendeWachtvak;
					}

					speler++;
				}
				else
				{
					if (modulo == 9 || modulo == -1) // Koppelvakje
					{
						huidigVak = new Koppelvak();


					}
					else
					{
						huidigVak = new Speelvak();
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