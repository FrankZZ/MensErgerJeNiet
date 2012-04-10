using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MensErgerJeNiet.Model;
using MensErgerJeNiet.Model.Vakken;

namespace MensErgerJeNiet.View
{
	/// <summary>
	/// Interaction logic for TextView.xaml
	/// </summary>
	public partial class TextView : Window
	{
		private Bord _model;

		public TextView(Bord bord)
		{
		//	_pionnen = pionnen;
			_model = bord;

			InitializeComponent();
			Attach();
		}

		private void OutputVak(int i, Vak vak)
		{
			textView.Text += vak.GetType().Name.ToString() + " " + i.ToString() + ": ";

			if (vak.HeeftPion())
			{
				Pion p = vak.Pion;
				textView.Text += "Pion " + p.Eigenaar.ToString();
			}
			else
			{
				textView.Text += "-";
			}
			textView.Text += "\r\n";
		}
		
		private void Attach()
		{
			int i = 0;
			int speler = 0;

			Vak beginVak = _model.EersteVak;

			i++;
			speler++;

			Vak huidigVak = beginVak.Volgende;

			// Regulier veld, het kruis
			while (huidigVak != beginVak && huidigVak.HeeftVolgende())
			{
				OutputVak(i, huidigVak);

				if (huidigVak is Koppelvak)
				{
					Koppelvak koppelVak = (Koppelvak)huidigVak;
					if (koppelVak.HeeftEindvak())
					{
						Eindvak eindVak = (Eindvak)koppelVak.Eindvak;
						//ArcObserver arc = _observers[_arcs[

						int j = 0;

						while (j < 4)
						{
							int idx = 56 + j + (speler * 4);

							OutputVak(idx, eindVak);

							if (eindVak.HeeftVolgende())
								eindVak = (Eindvak)eindVak.Volgende;

							j++;
						}
					}
					//MessageBox.Show(speler.ToString());
					Wachtvak wachtVak = _model.GetWachtvak(speler);

					int n = 0;

					while (n < 4)
					{
						//MessageBox.Show("WACHT " + n.ToString());
						int idx = 40 + n + (speler * 4);

						OutputVak(idx, wachtVak);

						if (wachtVak.HeeftVolgendeWachtvak())
							wachtVak = (Wachtvak)wachtVak.VolgendeWachtvak;

						n++;
					}

				}

				if (i % 10 == 0)
				{
					speler = ++speler % 4;
				}

				huidigVak = huidigVak.Volgende;
				i++;
			}
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{

		}
	}
}
