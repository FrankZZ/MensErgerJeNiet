using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace MensErgerJeNiet.Model.Vakken
{
    public class Beginvak : Vak
    {
		private Speler _eigenaar;

		public Speler Eigenaar
		{
			get
			{
				return _eigenaar;
			}
			set
			{
				_eigenaar = value;
				MessageBox.Show(value.ToString());
			}
		}
    }
}