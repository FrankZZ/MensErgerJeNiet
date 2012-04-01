using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MensErgerJeNiet.Models.Vakken;

namespace MensErgerJeNiet.Models
{
    class Speler
    {
		private Pion[] _pionnen;
		private Wachtvak[] _wachtvakken;

		public Pion[] Pionnen
		{
			get
			{
				return _pionnen;
			}
		}

		public Wachtvak[] Wachtvakken
		{
			get
			{
				return _wachtvakken;
			}
		}

		public Speler()
		{
			_pionnen = new Pion[4];
			_wachtvakken = new Wachtvak[4];

		}

    }
}