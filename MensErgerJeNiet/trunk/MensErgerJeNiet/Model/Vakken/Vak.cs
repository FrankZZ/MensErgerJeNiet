using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MensErgerJeNiet.Model.Vakken
{
    abstract class Vak
    {
		public event ChangedEventHandler Changed;

		private Vak _volgende;

		private Pion _pion;

		private Kleur _kleur;

		public Kleur Kleur
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

		public Vak Volgende
		{
			set
			{
				if (value != null)
				{ 
					_volgende = value;
				}
			}

			get
			{
				return _volgende;
			}
		}

		public Pion Pion
		{
			get
			{
				return _pion;
			}

			set
			{
				_pion = value;
			}
		}

		public bool HeeftVolgende()
		{
			return (_volgende != null);
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