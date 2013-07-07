using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using PropertyChangedDemo.Domain;

namespace PropertyChangedDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Person1 luke = new Person1();
            luke.Name = "Luke";

            Person2 lea = new Person2();
            lea.Name = "Lea";

            Person3 han = new Person3();
            han.Name = "Han";

            Person4 lando = new Person4();
            lando.Name = "Lando";

            MainWindow mainWindow = new MainWindow();
            mainWindow.DataContext = new List<object>() { luke, lea, han, lando };
            mainWindow.Show();
        }
    }
}
