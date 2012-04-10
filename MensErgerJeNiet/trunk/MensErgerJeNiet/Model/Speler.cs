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

		protected Pion[] _pionnen;
		protected Wachtvak _wachtvak;
		protected Beginvak _beginvak;
		protected SpelerKleur _kleur;

		protected Speler _volgende;

		protected String _naam;

		protected SpelerStatus _status;

		protected int _valueDiced;

		protected Dobbelsteen _dobbelsteen;

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
				Status = SpelerStatus.WachtOpPion;
			}
		}

		public virtual SpelerStatus Status
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
		protected int _nummer;

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

				for (int i = 0; i < 4; i++)
				{
					if (wachtVak.HeeftPion() == false)
					{
						return wachtVak;
					}
					if (wachtVak.HeeftVolgendeWachtvak())
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
					_beginvak = value;
					_beginvak.Eigenaar = this;
				}
			}

			get
			{
				return _beginvak;
			}
		}

		public Speler(Beginvak beginVak, Wachtvak wachtVak, Dobbelsteen dobbelsteen, String naam)
		{
			_naam = naam;
			_dobbelsteen = dobbelsteen;
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

		public void RollDice()
		{
			ValueDiced = _dobbelsteen.Gooi();
		}

		public void SetPionnen()
		{
			Wachtvak wachtVak = _wachtvak;
			int i = 0;

			while (i < 4)
			{
				wachtVak.Pion = _pionnen[i];
				_pionnen[i].Vak = wachtVak;

				if (wachtVak.HeeftVolgendeWachtvak())
					wachtVak = (Wachtvak) wachtVak.VolgendeWachtvak;

				i++;
			}	
		}

		public void onClickPion(Pion pion)
		{
			// zijn we aan de beurt? Zoniet, stop!
			if (_status != SpelerStatus.WachtOpPion)
				return;

			int steps = _valueDiced;

			// om van wacht->start te gaan is 1 stapje, ongeacht wat je gooit
			if (pion.Vak is Wachtvak)
			{
				steps += 1;
			}

			if (pion.move(steps))
			{
				if (PionnenThuishaven())
				{
					Status = SpelerStatus.Uit;
				}
				else
				{
					if (ValueDiced == 6)
					{
						Status = SpelerStatus.WachtOpDobbelsteen;
						return;
					}
					Status = SpelerStatus.WachtOpBeurt;
				}
			}
		}

		// Zijn er al pionnen in het spel of staan ze allemaal nog op een wachtvak?
		public bool PionInSpel()
		{
			foreach (Pion pion in Pionnen)
			{
				if (!(pion.Vak is Wachtvak) && !(pion.Vak is Eindvak))
					return true;
			}

			return false;
		}

		public bool PionnenThuishaven()
		{
			foreach (Pion pion in Pionnen)
			{
				if (!(pion.Vak is Eindvak))
					return false;
			}

			return true;
		}

		protected void OnChanged()
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