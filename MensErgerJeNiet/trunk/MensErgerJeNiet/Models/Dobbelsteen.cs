using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MensErgerJeNiet.Models
{
    class Dobbelsteen
    {
		static Random _randomizer = new Random();

		public int Gooi(int min, int max)
		{
			return _randomizer.Next(min, max);
		}
    }
}