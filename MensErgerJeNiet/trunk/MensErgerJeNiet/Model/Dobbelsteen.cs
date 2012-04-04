using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MensErgerJeNiet.Model
{
	public class Dobbelsteen
	{
		static Random _randomizer = new Random();

		public int Gooi()
		{
			return _randomizer.Next(1, (6 + 1));
		}
	}
}