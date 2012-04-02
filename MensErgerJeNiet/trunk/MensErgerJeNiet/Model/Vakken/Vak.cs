using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

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
			get
			{
				return _volgende;
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
				OnChanged();
			}
		}

		public bool HeeftVolgende()
		{
			return (_volgende != null);
		}

		public bool HeeftPion()
		{
			return (_pion != null);
		}

		private void OnChanged()
		{
			MessageBox.Show("onChanged before nullcheck");
			if (Changed != null)
			{
				MessageBox.Show("onChanged after nullcheck");
				Changed(this, new EventArgs());
			}
		}
    }
}