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

		public TextView(Bord model)
		{
			InitializeComponent();
		}

		private void Attach()
		{
			Vak eersteVak = _model.EersteVak;

		}
	}
}
