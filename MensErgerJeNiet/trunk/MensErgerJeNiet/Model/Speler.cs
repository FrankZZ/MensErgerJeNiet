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
		// Spelernummer, één van vier
		private int _nummer;

		public int Nummer
		{
			get
			{
				return _nummer;
			}
			set
			{
				_nummer = value;
			}
		}

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
					// Eigenaar toekennen aan beginvakje
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