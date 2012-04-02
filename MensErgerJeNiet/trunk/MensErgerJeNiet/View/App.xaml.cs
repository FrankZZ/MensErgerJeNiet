using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using MensErgerJeNiet.Controller;

namespace MensErgerJeNiet
{
	public partial class App : Application
	{
		public App()
		{
			new Spel();
		}
	}
}