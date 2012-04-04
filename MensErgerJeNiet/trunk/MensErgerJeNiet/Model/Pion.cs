using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MensErgerJeNiet.Model.Vakken;
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

		public Kleur Kleur
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
			}
		}

		public void move(int steps = 1)
		{
			Vak vak = _vak;
			for (int i = 0; i < steps; i++) vak = vak.Volgende;

			vak.Pion = this; //geslagen, oude replaced.
			_vak.Pion = null;
		}

		public void hit()
		{
			// Terug naar eerste beschikbare wachtvak
			_vak = _eigenaar.Wachtvak;
			
			_vak.Pion = this;
		}
    }
}