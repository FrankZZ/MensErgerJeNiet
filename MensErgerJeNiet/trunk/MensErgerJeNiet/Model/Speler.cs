using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MensErgerJeNiet.Model.Vakken;
using System.Windows;

namespace MensErgerJeNiet.Model
{
    class Speler
    {
		private Pion[] _pionnen;
		private Wachtvak[] _wachtvakken;
		private Beginvak _beginvak;
		private Kleur _kleur;

		// Spelernummer, één van vier
		private int _nummer;

		public Kleur Kleur
		{
			get
			{
				return _kleur;
			}
		}
		
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

		public Speler(Beginvak beginVak)
		{
			_beginvak = beginVak;

			_pionnen = new Pion[4];

			for (int i = 0; i < _pionnen.Length; i++)
			{
				_pionnen[i] = new Pion();
			}
			_beginvak.Pion = _pionnen[0];
		}

    }
}