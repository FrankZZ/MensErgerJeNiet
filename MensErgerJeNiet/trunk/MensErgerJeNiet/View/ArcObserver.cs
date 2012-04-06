using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Expression.Shapes;
using MensErgerJeNiet.Model.Vakken;
using MensErgerJeNiet.Model;
using System.Windows.Media;
using System.Windows;

namespace MensErgerJeNiet.View
{
	public class Observer
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

		public Observer(Arc arc)
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

		public void OnClick()
		{
			_vak.OnClick();
		}
	}
}