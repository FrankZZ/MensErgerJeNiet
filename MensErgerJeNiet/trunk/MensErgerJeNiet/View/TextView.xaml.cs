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
		private List<Pion[]> _pionnen;
		private String _content;

		public TextView(List<Pion[]> pionnen)
		{
			_pionnen = pionnen;

			InitializeComponent();
			Attach();
		}

		private void Attach()
		{
			foreach (Pion[] pionnen in _pionnen)
			{
				for (int i = 1; i < 5; i++)
				{
					Pion p = pionnen[i-1];

					textView.Text += p.Eigenaar + ": Pion " + i.ToString() + " - " + p.Vak.GetType().Name.ToString() + "\r\n";
				}
			}
		}
	}
}
