using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;



namespace NET.Tools
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            base.OnStartup(e);

            Console.WriteLine("App: " + AppDomain.CurrentDomain.GetApplicationFilename());
        }
    }
}
