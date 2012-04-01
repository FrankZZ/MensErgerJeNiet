using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MensErgerJeNiet.Models.Vakken;

namespace MensErgerJeNiet.Models
{
	enum Kleur
	{
		Rood,
		Blauw,
		Groen,
		Geel
	}

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