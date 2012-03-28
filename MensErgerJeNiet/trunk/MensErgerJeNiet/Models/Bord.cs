using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MensErgerJeNiet.Models.Vakken;

namespace MensErgerJeNiet.Models
{
    class Bord
    {
		private Vak _beginvak;

		public Bord()
		{
			_beginvak = new Beginvak();
			Vak vorigVak;

			// i = 1 omdat het startvakje hierboven al gemaakt is
			for (int i = 1; i < 40; i++) // i = 1 omdat het startvakje hierboven al gemaakt is
			{
				Vak huidigVak;

				int modulo = i % 10;

				if (modulo == 0)		//Startvakje
				{
					huidigVak = new Beginvak();
				}
				else if (modulo == 9)	//Koppelvakje voor eindvakjes
				{
					huidigVak = new Speelvak();
					// Methode(s) om eindvakjes te koppelen
				}
				else
				{
					huidigVak = new Speelvak();
				}

				vorigVak = huidigVak;
			}
		}
    }
}