using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MensErgerJeNiet.Models.Vakken;

namespace MensErgerJeNiet.Models
{
    class Bord
    {
		private Vak _eerstevak;
		private Vak[] _startvakken;

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

			// Eerste vakje alvast maken vóór de loop
			_eerstevak = new Beginvak();
			_startvakken[speler] = _eerstevak;
			speler++;

			Vak vorigVak;

			
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

				vorigVak = huidigVak;
			}
		}
    }
}