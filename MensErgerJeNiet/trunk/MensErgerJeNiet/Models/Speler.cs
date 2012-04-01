using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MensErgerJeNiet.Models
{
    class Speler
    {
		private Pion[] _pionnen;

		public Pion[] Pionnen
		{
			get
			{
				return _pionnen;
			}
		}

		public Speler()
		{
			_pionnen = new Pion[4];

		}

    }
}