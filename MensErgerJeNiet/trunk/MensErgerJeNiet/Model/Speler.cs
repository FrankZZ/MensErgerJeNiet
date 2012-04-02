using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MensErgerJeNiet.Model.Vakken;

namespace MensErgerJeNiet.Model
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
					_beginvak.Eigenaar = this;
				}
			}
			get
			{
				return _beginvak;
			}
		}

		public Speler()
		{
			_pionnen = new Pion[4];

		}

    }
}