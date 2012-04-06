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

		public void move(int steps)
		{
			Vak vak = _vak;
			for (int i = 0; i < steps; i++)
			{
				vak = vak.Volgende;
				if (vak is Koppelvak)
				{
					Koppelvak koppelVak = (Koppelvak)vak;
					
					MessageBox.Show(koppelVak.Volgende.ToString());

					MessageBox.Show(((Beginvak)koppelVak.Volgende).Eigenaar.ToString());
					if (((Beginvak) koppelVak.Volgende).Eigenaar == _eigenaar)
					{
						vak = koppelVak.Eindvak;
					}
				}
			}

			vak.Pion = this; //geslagen, oude replaced.

			_vak.Pion = null;

			_vak = vak;
		}

		public void hit()
		{
			// Terug naar eerste beschikbare wachtvak
			_vak = _eigenaar.Wachtvak;
			
			_vak.Pion = this;
		}

		public void onClick()
		{
			
		}
    }
}