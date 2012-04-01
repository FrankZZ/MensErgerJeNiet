using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MensErgerJeNiet.Models.Vakken
{
    abstract class Vak
    {
		private Vak _volgende;

		private Pion _pion;

		public Vak Volgende
		{
			set
			{
				if (value != null)
				{ 
					_volgende = value;
				}
			}
		}

		public Pion Pion
		{
			get
			{
				return _pion;
			}

			set
			{
				_pion = value;
			}
		}
    }
}