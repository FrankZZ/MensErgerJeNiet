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
		private Beginvak _beginvak;

		public Pion[] Pionnen
		{
			get
			{
				return _pionnen;
			}
		}

		public Beginvak Beginvak
		{
			set
			{
				if (value != null)
				{
					_beginvak = value;
				}
			}
		}

		public Speler()
		{
			_pionnen = new Pion[4];

		}

    }
}