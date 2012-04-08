using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MensErgerJeNiet.Model.Vakken
{
	public class Wachtvak : Vak
	{
		private Wachtvak _volgendeWachtvak;

		public Wachtvak VolgendeWachtvak
		{
			get
			{
				return _volgendeWachtvak;
			}

			set
			{
				_volgendeWachtvak = value;
			}
		}

		public bool HeeftVolgendeWachtvak()
		{
			return _volgendeWachtvak != null;
		}
	}
}