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

		public void move(int steps = 1)
		{
			Vak vak = _vak;
			for (int i = 0; i < steps; i++) vak = vak.Volgende;

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
			_eigenaar.onClickPion(this);
		}
    }
}