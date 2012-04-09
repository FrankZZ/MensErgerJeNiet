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

			Vak huidigVak = null;
			Vak vorigVak = new Beginvak();

			_startvakken[speler] = (Beginvak)vorigVak;
			_eerstevak = vorigVak;
			MaakWachtvakken(speler);
			speler++;

			// i = 1 omdat het startvakje hierboven al gemaakt is
			for (int i = 1; i < 40; i++) // i = 1 omdat het startvakje hierboven al gemaakt is
			{
				int modulo = i % 10;

				if (modulo == 0) // Startvakje
				{
					huidigVak = new Beginvak();
					_startvakken[speler] = (Beginvak)huidigVak;

					MaakWachtvakken(speler);

					speler = ++speler % 4;
				}
				else
				{
					if (modulo == 9) // Koppelvakje
					{
						huidigVak = MaakKoppelvak();
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
			huidigVak.Volgende = (Beginvak)_eerstevak;
		}

		private Koppelvak MaakKoppelvak()
		{
			Koppelvak huidigVak = new Koppelvak();

			Eindvak nieuwVak = new Eindvak();
			((Koppelvak)huidigVak).Eindvak = nieuwVak;

			for (int j = 0; j < 3; j++)
			{
				Eindvak oudVak = nieuwVak;

				nieuwVak = new Eindvak();

				oudVak.Volgende = nieuwVak;
				nieuwVak.Vorige = oudVak;
			}

			return huidigVak;
		}

		private void MaakWachtvakken(int speler)
		{
			Wachtvak wachtVak = new Wachtvak();

			wachtVak.Volgende = _startvakken[speler];

			_wachtvakken[speler] = wachtVak;

			for (int j = 0; j < 3; j++)
			{
				wachtVak.VolgendeWachtvak = new Wachtvak();
				
				wachtVak = (Wachtvak)wachtVak.VolgendeWachtvak;

				wachtVak.Volgende = _startvakken[speler];
			}
		}
	}
}