using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MensErgerJeNiet.Model.Vakken
{
    public class Koppelvak : Vak
    {	
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
    }
}