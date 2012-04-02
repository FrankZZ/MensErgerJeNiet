using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MensErgerJeNiet.Model.Vakken
{
    abstract class Vak
    {
		public event ChangedEventHandler Changed;

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

		private void OnChanged()
		{
			if (Changed != null)
			{
				Changed(this, new EventArgs());
			}
		}
    }
}