using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MensErgerJeNiet.Model.Vakken;
using MensErgerJeNiet.Shared;

using System.Windows;

namespace MensErgerJeNiet.Model
{
	public class Pion
    {
		private Vak _vak;

		private Speler _eigenaar;

		public Speler Eigenaar
		{
			get
			{
				return _eigenaar;
			}
			set
			{
				_eigenaar = value;
			}
		}

		public SpelerKleur Kleur
		{
			get
			{
				return _eigenaar.Kleur;
			}
		}

		public Vak Vak
		{
			get
			{
				return _vak;
			}

			set
			{
				_vak = value;
/*				// Onszelf op het vakje zetten
				value.Pion = this;
 */
			}
		}

		public bool move(int steps)
		{
			if (_eigenaar.PionInSpel())
			{
				if (_eigenaar.ValueDiced != 6 && _vak is Wachtvak)
					return false;
			}

			Vak vak = _vak;

			for (int i = 0; i < steps && vak.HeeftVolgende(); i++)
			{
				// Koppelvak tegengekomen.
				if (vak is Koppelvak)
				{
					Koppelvak koppelVak = (Koppelvak)vak;
					
					if (((Beginvak) koppelVak.Volgende).Eigenaar == _eigenaar)
					{
						vak = koppelVak.Eindvak;
						continue;
					}
				}

				// Binnen de loop steeds een vakje verzetten.
				vak = vak.Volgende;
			}

			// Binnen de thuishaven.
			if (vak is Eindvak)
			{
				if (vak.HeeftPion())
				{
					while (!(vak is Koppelvak))
					{
						vak = ((Eindvak)vak).Vorige;
					}
				}
			}

			vak.Pion = this; // Geslagen, oude replaced.
			_vak.Pion = null;
			_vak = vak;

			return true;
		}

		public void hit()
		{
			// Terug naar eerste beschikbare wachtvak
			_vak = _eigenaar.Wachtvak;
			_vak.Pion = this;
		}

    }
}