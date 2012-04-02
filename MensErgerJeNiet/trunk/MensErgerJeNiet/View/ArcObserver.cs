using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Expression.Shapes;
using MensErgerJeNiet.Model.Vakken;
using MensErgerJeNiet.Model;
using System.Windows.Media;

namespace MensErgerJeNiet.View
{
	public class ArcObserver
	{
		private Arc _arc;

		public ArcObserver(Arc arc)
		{
			_arc = arc;
		}

		public void update(Object o, EventArgs e)
		{
			Vak vak = (Vak) o;

			Brush kleur = Brushes.LightGray;

			if (vak.HeeftPion())
			{
				Pion pion = vak.Pion;
				switch (pion.Kleur)
				{
					case Kleur.Blauw: kleur = Brushes.Blue; break;
					case Kleur.Groen: kleur = Brushes.Green; break;
					case Kleur.Geel: kleur = Brushes.Yellow; break;
					case Kleur.Rood: kleur = Brushes.Red; break;
				}
				_arc.ArcThickness = 8;
			}
			else
			{
				// geen pion op vakje
				_arc.ArcThickness = 20;
			}
			_arc.Fill = kleur;
		}
	}
}
