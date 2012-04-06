using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MensErgerJeNiet.Shared
{
	class StringEventArgs : EventArgs
	{
		private String _arg;

		public StringEventArgs(String arg)
		{
			_arg = arg;
		}

		public String ToString()
		{
			return _arg;
		}
	}
}