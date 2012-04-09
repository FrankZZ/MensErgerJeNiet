using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MensErgerJeNiet.Model.Vakken
{
	public class Eindvak : Vak
	{
		private Eindvak _vorige;

		public Eindvak Vorige
		{
			get
			{
				return _vorige;
			}
			set
			{
				_vorige = value;
			}
		}
	}
}