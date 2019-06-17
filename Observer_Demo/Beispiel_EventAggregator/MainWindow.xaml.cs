using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Beispiel_EventAggregator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            EventAggregator.Subscribe(labelText, "neuerMesswert", data =>
              {
                  labelText.Content = data;
              });
        }

        private void ButtonFenster_Click(object sender, RoutedEventArgs e)
        {
            ZweitesFenster z2 = new ZweitesFenster();
            z2.Show();
        }
    }
}
