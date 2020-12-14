using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using System.Windows.Threading;


namespace Drink_Water {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();
            Loaded += MainWindowLoaded;

        }

        private void MainWindowLoaded(object sender, RoutedEventArgs e) {
            var timer = new DispatcherTimer { Interval = TimeSpan.FromMinutes(3)};
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
            
        }

        public double norma;

        private void Timer_Tick(object sender, EventArgs e) {
            Notification notification = new Notification();
            notification.Show();
        }
        
        private void Calculation_Click(object sender, RoutedEventArgs e) {
            bool IsCorrect = true;
            for(int i = 0; i < NameBox.Text.Length; i++) {
                
                if (Char.IsDigit(NameBox.Text[i])) {
                    MessageBox.Show("Incorrect input! You can enter only symbols in name field");
                    IsCorrect = false;
                    break;
                }

            }

            for (int i = 0; i < WeightBox.Text.Length; i++) {
                
                if (!Char.IsDigit(WeightBox.Text[i])) {
                    MessageBox.Show("Incorrect input! You can enter only digits in weight field");
                    IsCorrect = false;
                    break;
                }

            }

            if (NameBox.Text == string.Empty || WeightBox.Text == string.Empty) {
                MessageBox.Show("Fields can not be empty! Please provide information");
                IsCorrect = false;
            }

            if(IsCorrect) { 
                Window1 wdw1 = new Window1(NameBox.Text, Int32.Parse(WeightBox.Text));
                wdw1.Show();
                string weight = WeightBox.Text;
                double wght = Convert.ToInt32(weight);
                double norm = 30 * wght;
        
                string m = norm.ToString() + " " + "mililiters";
                //string s = m + " " + "mililiters";
        
                wdw1.NormLabel.Content = m;
                wdw1.name = NameBox.Text;
                wdw1.weight = Int32.Parse(WeightBox.Text);
                this.Close();
            }
        }

        private void Help_Click(object sender, RoutedEventArgs e) {
            Help help = new Help();
            help.Show();
        }
    }
}
