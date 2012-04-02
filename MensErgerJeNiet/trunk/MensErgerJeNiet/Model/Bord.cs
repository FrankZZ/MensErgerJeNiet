using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MensErgerJeNiet.Model.Vakken;

namespace MensErgerJeNiet.Model
{
    class Bord
    {
		private Vak _eerstevak;
		private Vak[] _startvakken;

		public Vak EersteVak
		{
			get
			{
				return _eerstevak;
			}
		}

		public Beginvak GetStartVak(int speler)
		{
			if (speler >= 0 && speler < _startvakken.Length)
			{
				return (Beginvak) _startvakken[speler];
			}
			return null;
		}

		public Bord()
		{
			int speler = 0;
			_startvakken = new Vak[4];

			// Eerste vakje alvast maken vóór de loop
			_eerstevak = new Beginvak();
			_startvakken[speler] = _eerstevak;
			speler++;

			// eerste vak is in dit geval de vorige voor de loop
			Vak vorigVak = _eerstevak;

			
			// i = 1 omdat het startvakje hierboven al gemaakt is
			for (int i = 1; i < 40; i++) // i = 1 omdat het startvakje hierboven al gemaakt is
			{
				Vak huidigVak;

				int modulo = i % 10;

				if (modulo == 0) // Startvakje
				{
					huidigVak = new Beginvak();
					_startvakken[speler] = huidigVak;
				}
				else
				{
					huidigVak = new Speelvak();

					if (modulo == 9)
					{
						// Extra methodes voor koppelvak
					}
				}
				// Koppel vorige vak aan huidige, linked list
				vorigVak.Volgende = huidigVak;

				vorigVak = huidigVak;
			}
		}
    }
}