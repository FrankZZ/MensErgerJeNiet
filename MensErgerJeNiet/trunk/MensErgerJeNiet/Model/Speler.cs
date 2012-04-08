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
		private Wachtvak _wachtvak;
		private Beginvak _beginvak;
		private SpelerKleur _kleur;

		private Speler _volgende;

		private String _naam;

		private SpelerStatus _status;

		private int _valueDiced;

		public Speler Volgende
		{
			set
			{
				_volgende = value;
			}
			get
			{
				return _volgende;
			}
		}

		public int ValueDiced
		{
			get
			{
				return _valueDiced;
			}
			set
			{
				_valueDiced = value;
				// OnChanged wordt gevuurd via Status.
				Status = SpelerStatus.WachtOpPion;
			}
		}

		public SpelerStatus Status
		{
			get
			{
				return _status;
			}

			set
			{
				_status = value;
				OnChanged();
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

		//return eerste lege wachtvak, alles vol = null
		public Wachtvak Wachtvak
		{
			get
			{
				Wachtvak wachtVak = _wachtvak;

				while (wachtVak.HeeftVolgendeWachtvak())
				{
					if (wachtVak.HeeftPion() == false)
					{
						return wachtVak;
					}
					wachtVak = (Wachtvak) wachtVak.VolgendeWachtvak;
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
					// Eigenaar toekennen aan beginvakje
					value.Eigenaar = this;
					_beginvak = value;
				}
			}

			get
			{
				return _beginvak;
			}
		}

		public Speler(Beginvak beginVak, Wachtvak wachtVak, String naam)
		{
			_naam = naam;

			_status = SpelerStatus.WachtOpBeurt;

			_wachtvak = wachtVak;

			Beginvak = beginVak;

			_pionnen = new Pion[4];
			
			for (int i = 0; i < _pionnen.Length; i++)
			{
				_pionnen[i] = new Pion();
				_pionnen[i].Eigenaar = this;
			}
		}

		public void SetPionnen()
		{
			Wachtvak wachtVak = _wachtvak;
			int i = 0;

			while (wachtVak.HeeftVolgendeWachtvak())
			{
				wachtVak.Pion = _pionnen[i];
				_pionnen[i].Vak = wachtVak;

				wachtVak = (Wachtvak) wachtVak.VolgendeWachtvak;
				i++;
			}	
		}

		public void onClickPion(Pion pion)
		{
			// zijn we aan de beurt?
			if (_status != SpelerStatus.WachtOpPion)
				return;

			int steps = _valueDiced;

			// extra stap om van wacht->start te gaan
			if (pion.Vak is Wachtvak)
			{
				/*if (steps != 6)
				{
					Status = SpelerStatus.WachtOpBeurt;
					return;
				}*/
				steps = 1;
				pion.move(steps);
				Status = SpelerStatus.WachtOpDobbelsteen;
			}
			else
			{
				pion.move(steps);
				Status = SpelerStatus.WachtOpBeurt;
			}
		}

		private void OnChanged()
		{
			if (Changed != null)
			{
				Changed(this, new EventArgs());
			}
		}

		public override String ToString()
		{
			return _naam;
		}
    }
}