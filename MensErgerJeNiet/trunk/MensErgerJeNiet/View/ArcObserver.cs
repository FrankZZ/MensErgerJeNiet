using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Expression.Shapes;
using MensErgerJeNiet.Model.Vakken;
using MensErgerJeNiet.Model;
using MensErgerJeNiet.Shared;
using System.Windows.Media;
using System.Windows;

namespace MensErgerJeNiet.View
{
	public class ArcObserver
	{
		private Arc _arc;
		private Brush _kleur;
		private Vak _vak;

		public Vak Vak
		{
			set
			{
				_vak = value;
			}
		}

		public ArcObserver(Arc arc)
		{
			_arc = arc;
			_kleur = arc.Fill;
		}

		public void updateFromVak(Object o, EventArgs e)
		{
			Vak vak = (Vak) o;

			Brush kleur = _kleur;

			if (vak.HeeftPion())
			{
				Pion pion = vak.Pion;
				switch (pion.Kleur)
				{
					case SpelerKleur.Blauw: kleur = Brushes.Blue; break;
					case SpelerKleur.Groen: kleur = Brushes.Green; break;
					case SpelerKleur.Geel: kleur = Brushes.Yellow; break;
					case SpelerKleur.Rood: kleur = Brushes.Red; break;
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

		public void OnClick()
		{
			_vak.OnClick();
		}
	}
}