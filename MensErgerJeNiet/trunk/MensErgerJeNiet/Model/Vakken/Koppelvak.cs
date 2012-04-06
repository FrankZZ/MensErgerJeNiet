using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MensErgerJeNiet.Model.Vakken
{
    public class Koppelvak : Vak
    {
		private Speler _eigenaar;
		
		private Eindvak _eindvak;
		
		public Eindvak Eindvak
		{
			get
			{
				return _eindvak;
			}
			set
			{
				_eindvak = value;
			}
		}

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