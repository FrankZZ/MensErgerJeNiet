using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MensErgerJeNiet.Model.Vakken
{
    class Beginvak : Vak
    {
		private Speler _eigenaar;
		private Kleur _kleur;

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
    }
}