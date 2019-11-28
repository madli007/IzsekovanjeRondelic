using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonCalculate_Click(object sender, RoutedEventArgs e)
        {
            // parse input data from textboxes
            int.TryParse(TextBoxRadius.Text, out int radius);
            int.TryParse(TextBoxDistanceC2C.Text, out int minDistC2C);
            int.TryParse(TextBoxDistanceC2E.Text, out int minDistC2Edge);
            int.TryParse(TextBoxLength.Text, out int length);
            int.TryParse(TextBoxWidth.Text, out int width);

            bool isOk = IsInputOK(radius, minDistC2C, minDistC2Edge, length, width);

            if (isOk)
            {
                Tape t = new Tape(length, width);
                Rondelica r = new Rondelica(radius, minDistC2C, minDistC2Edge, new Library.Point());
                Draw(t, r);
                FillListBoxWithPositions(t);
            }
            else
            {
                MessageBox.Show("POGOJI: Polmer > 0, dolžina <= 10000, širina <= 2000", "Napačne vrednosti", 
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private bool IsInputOK(int radius, int minDistC2C, int minDistC2Edge, int length, int width)
        {
            bool ok = true;

            if (radius == 0 || length > 10000 || width > 2000)
            {
                ok = false;
            }


            return ok;
        }

        private void FillListBoxWithPositions(Tape t)
        {
            ListBoxPositions1.Items.Clear();
            for (int i = 0; i < t.ListOfCylinders.Count; i++)
            {
                string listBoxItem =
                    "X: " + t.ListOfCylinders[i].Position.X.ToString() +
                    ", Y: " + t.ListOfCylinders[i].Position.Y.ToString();
                ListBoxPositions1.Items.Add(listBoxItem);
            }
        }

        private void Draw(Tape t, Rondelica r)
        {
            Canvas1.Children.Clear();
            int scale = 1;

            int a = t.MaxNumberOfCylindersRecPattern(r);

            Rectangle rec = new Rectangle
            {
                Width = t.Length,
                Height = t.Width,
                Stroke = Brushes.Black
            };
            Canvas1.Children.Add(rec);

            for (int i = 0; i < t.ListOfCylinders.Count; i++)
            {
                Ellipse e = new Ellipse
                {
                    Height = t.ListOfCylinders[i].Radius * 2,
                    Width = t.ListOfCylinders[i].Radius * 2,
                    Stroke = Brushes.Black
                };

                Canvas.SetLeft(e, t.ListOfCylinders[i].Position.X - t.ListOfCylinders[i].Radius);
                Canvas.SetTop(e, t.ListOfCylinders[i].Position.Y - t.ListOfCylinders[i].Radius);

                Canvas1.Children.Add(e);
            }

            Max1.Content = a.ToString();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void ButtonFillWithData_Click(object sender, RoutedEventArgs e)
        {
            TextBoxWidth.Text = "100";
            TextBoxLength.Text = "200";
            TextBoxRadius.Text = "10";
            TextBoxDistanceC2C.Text = "5";
            TextBoxDistanceC2E.Text = "10";
        }

        private void MenuItemIzhod_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
