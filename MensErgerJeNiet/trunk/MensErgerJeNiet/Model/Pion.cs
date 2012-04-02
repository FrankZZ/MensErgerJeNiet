using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MensErgerJeNiet.Model.Vakken;

namespace MensErgerJeNiet.Model
{
	class Pion
    {
		private Kleur _kleur;

		private Vak _vak;

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

    }
}