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
using MensErgerJeNiet.Shared;

namespace MensErgerJeNiet.View
{
	/// <summary>
	/// Interaction logic for StartView.xaml
	/// </summary>
	public partial class StartView : Window
	{
		public ChangedEventHandler Changed;

		public StartView()
		{
			InitializeComponent();
		}

		private void button1_MouseDown(object sender, MouseButtonEventArgs e)
		{
			OnChanged(ViewEvents.DiceClick, Convert.ToInt32(playerCount.SelectedValue.ToString()));
		}

		private void OnChanged(ViewEvents evt, int value)
		{
			if (Changed != null)
			{
				Changed(this, new EventArgs<ViewEvents, int>(evt, value));
			}
		}
	}
}
