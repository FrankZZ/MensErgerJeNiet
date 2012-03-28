using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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


    }
}