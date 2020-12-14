using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Drawing;
using System.ComponentModel;

namespace Drink_Water {
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window {
       
        public int weight;
        public string name;
        public Window1(string name, int weight) {
            InitializeComponent();
            Loaded += WindowLoaded;

            this.name = name;
            this.weight = weight;
        }

        private void WindowLoaded(object sender, RoutedEventArgs e) {
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();

        }

        private void Timer_Tick(object sender, EventArgs e) {
            if(count == 0) {
                C1.Visibility = Visibility.Hidden;
                C2.Visibility = Visibility.Hidden;
                C3.Visibility = Visibility.Hidden;
                C4.Visibility = Visibility.Hidden;
                C5.Visibility = Visibility.Hidden;
                C6.Visibility = Visibility.Hidden;
                C7.Visibility = Visibility.Hidden;
            }
        }


        public int count;
       
        private void Button_Click(object sender, RoutedEventArgs e) {
            count += 100;
            count.ToString();
            ConsLabel.Content = count;
            C1.Visibility = Visibility.Visible;
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            count += 150;
            count.ToString();
            ConsLabel.Content = count;
            C2.Visibility = Visibility.Visible;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) {
            
            count -= 100;
            count.ToString();
            ConsLabel.Content = count;

        }

        private void Button_Click_3(object sender, RoutedEventArgs e) {
            count -= 150;
            count.ToString();
            ConsLabel.Content = count;

        }

        private void Button_Click_4(object sender, RoutedEventArgs e) {
            count += 175;
            count.ToString();
            ConsLabel.Content = count;
            C3.Visibility = Visibility.Visible;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e) {
            count -= 175;
            count.ToString();
            ConsLabel.Content = count;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e) {
            count += 200;
            count.ToString();
            ConsLabel.Content = count;
            C4.Visibility = Visibility.Visible;
        }

        private void Button_Click_7(object sender, RoutedEventArgs e) {
            count -= 200;
            count.ToString();
            ConsLabel.Content = count;

        }

        private void Button_Click_8(object sender, RoutedEventArgs e) {
            count += 300;
            count.ToString();
            ConsLabel.Content = count;
            C5.Visibility = Visibility.Visible;
        }

        private void Button_Click_9(object sender, RoutedEventArgs e) {
            count -= 300;
            count.ToString();
            ConsLabel.Content = count;

        }

        private void Button_Click_10(object sender, RoutedEventArgs e) {
            count += 400;
            count.ToString();
            ConsLabel.Content = count;
            C6.Visibility = Visibility.Visible;
        }

        private void Button_Click_11(object sender, RoutedEventArgs e) {
            count -= 400;
            count.ToString();
            ConsLabel.Content = count;

        }

        private void Button_Click_12(object sender, RoutedEventArgs e) {
            bool IsCorrect = true;
            if (Custom.Text == string.Empty) {
                MessageBox.Show("This field can not be empty!");
                IsCorrect = false;
            }

            for(int i = 0; i < Custom.Text.Length; i++) {
                if (!Char.IsDigit(Custom.Text[i])) {
                    MessageBox.Show("You can enter only digits here!");
                    Custom.Text = "";
                    IsCorrect = false;
                    break;
                    
                }
            }

            if (IsCorrect) {
                count += Int32.Parse(Custom.Text);
                count.ToString();
                ConsLabel.Content = count;
                C7.Visibility = Visibility.Visible;
            }

        }

        private void Button_Click_13(object sender, RoutedEventArgs e) {
            count -= Int32.Parse(Custom.Text);
            count.ToString();
            ConsLabel.Content = count;

        }

        private void PlotBut_Click(object sender, RoutedEventArgs e) {

            using (DataContext db = new DataContext()) {

                int t;
                
                if(db.User.ToList().Count == 0) {
                    t = 0;
                }
                
                else {
                    t = db.User.Select(i => i.ID).Max();
                }
                
                DataB user = new DataB { ID = ++t, Username = name, Weight = weight, WatAmount = count, Day = DateTime.Now };
                
                db.User.AddAsync(user);
                db.SaveChangesAsync();                
            }

            DataContext data = new DataContext();
            List<double> vs = data.User.Select(u => u.WatAmount).ToList();

            double[] vs1 = new double[vs.Count];
            for(int i = 0; i < vs.Count; i++) {
                vs1[i] = i + 1;
            }

            if(vs.Count > 1) {
                Plot.plt.PlotScatter(vs1, vs.ToArray());
            }

            else {
                MessageBox.Show("You need at least 2 days to build a plot");
            } 
        }
    }
}