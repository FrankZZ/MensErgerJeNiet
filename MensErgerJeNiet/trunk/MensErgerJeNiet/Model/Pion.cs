using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MensErgerJeNiet.Model.Vakken;
using System.Windows;

namespace MensErgerJeNiet.Model
{
	class Pion
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

		public void move(int steps)
		{
			if (_vak.Volgende.Pion != null)
			{
				Vak vak = _vak;
				for (int i = 0; i < steps; i++) vak = vak.Volgende;

				vak.Pion = this;
				_vak.Pion = null;
			}
		}
    }
}