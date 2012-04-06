using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MensErgerJeNiet.Model.Vakken;
using System.Windows;
using MensErgerJeNiet.Shared;

namespace MensErgerJeNiet.Model
{
    public class Speler
    {
		public event ChangedEventHandler Changed;

		private Pion[] _pionnen;
		private Wachtvak[] _wachtvakken;
		private Beginvak _beginvak;
		private SpelerKleur _kleur;

		private SpelerStatus _status;

		public SpelerStatus Status
		{
			get
			{
				return _status;
			}
		}

		// Spelernummer, één van vier
		private int _nummer;

		public SpelerKleur Kleur
		{
			get
			{
				return _kleur;
			}
			set
			{
				_kleur = value;
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

		public Wachtvak GetWachtvak(int index)
		{
			if (index >= 0 && index < _wachtvakken.Length)
			{
				return _wachtvakken[index];
			}
			return null;
		}

		//return eerste lege wachtvak, alles vol = null
		public Wachtvak Wachtvak
		{
			get
			{
				for (int i = 0; i < _wachtvakken.Length; i++)
				{
					if (!_wachtvakken[i].HeeftPion())
					{
						return _wachtvakken[i];
					}
				}

				return null;
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
			_status = SpelerStatus.WachtOpBeurt;

			_beginvak = beginVak;

			_pionnen = new Pion[4];
			_wachtvakken = new Wachtvak[4];

			for (int i = 0; i < _pionnen.Length && i < _wachtvakken.Length; i++)
			{
				_pionnen[i] = new Pion();
				_pionnen[i].Eigenaar = this;
				
				_wachtvakken[i] = new Wachtvak();
				_wachtvakken[i].Volgende = _beginvak;
			}
		}

		public void SetPionnen()
		{
			for (int i = 0; i < _wachtvakken.Length; i++)
			{
				_wachtvakken[i].Pion = _pionnen[i];
				_pionnen[i].Vak = _wachtvakken[i];
			}
		}

		public void doTurn(int steps)
		{
			OnChanged();
		}

		private void OnChanged()
		{
			if (Changed != null)
			{
				Changed(this, new EventArgs());
			}
		}
    }
}