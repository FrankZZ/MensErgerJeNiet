using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MensErgerJeNiet.Shared;
using MensErgerJeNiet.Model.Vakken;

namespace MensErgerJeNiet.Model
{
	class BotSpeler : Speler
	{
		public BotSpeler(Beginvak beginVak, Wachtvak wachtVak, Dobbelsteen dobbelsteen, String naam)
			: base(beginVak, wachtVak, dobbelsteen, naam)
		{

		}


		public override SpelerStatus Status
		{
			get
			{
				return _status;
			}

			set
			{
				_status = value;

				switch (value)
				{
					case SpelerStatus.WachtOpPion: PickPion(); break;
					case SpelerStatus.WachtOpDobbelsteen: RollDice(); break;
				}

				OnChanged();
			}
		}

		private void PickPion()
		{
			Pion bestPion = _pionnen[0];

			for (int i = 1; i<_pionnen.Length; i++)
			{
				Pion p = _pionnen[i];
				Vak vak = p.Vak;

				if (vak is Wachtvak)
				{

				}
			}
		}

		private int PionPriority(Pion p)
		{
			int priority = 0;

			

			return priority;
		}


	}
}
