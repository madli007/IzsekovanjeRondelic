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
            bool recPattern = RadioButtonRecPattern.IsChecked.Value;

            // check if the parameters are ok
            bool isOk = IsInputOK(radius, minDistC2C, minDistC2Edge, length, width);

            if (isOk)
            {
                Tape tape = new Tape(length, width);
                Rondelica rondelica = new Rondelica(radius, minDistC2C, minDistC2Edge, new Library.Point());
                Draw(tape, rondelica, recPattern);
                FillListBoxWithPositions(tape);
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

        /// <summary>
        /// Fills list box with cylinder positions
        /// </summary>
        /// <param name="tape"></param>
        private void FillListBoxWithPositions(Tape tape)
        {
            ListBoxPositions1.Items.Clear();
            for (int i = 0; i < tape.ListOfCylinders.Count; i++)
            {
                string listBoxItem =
                    "X: " + tape.ListOfCylinders[i].Position.X.ToString() +
                    ", Y: " + tape.ListOfCylinders[i].Position.Y.ToString();
                ListBoxPositions1.Items.Add(listBoxItem);
            }
        }

        /// <summary>
        /// Draw cylinders on tape with canvas element
        /// </summary>
        /// <param name="tape"></param>
        /// <param name="rondelica"></param>
        /// <param name="recPattern"></param>
        private void Draw(Tape tape, Rondelica rondelica, bool recPattern)
        {
            Canvas1.Children.Clear();
            int scale = 1;

            int maxNumber = 0;
            if (recPattern)
            {
                maxNumber = tape.MaxNumberOfCylindersRecPattern(rondelica);
            }
            else
            {
                maxNumber = tape.MaxNumberOfCylindersTriangularPattern(rondelica);
            }

            Rectangle rectangle = new Rectangle
            {
                Width = tape.Length,
                Height = tape.Width,
                Stroke = Brushes.Black
            };
            Canvas1.Children.Add(rectangle);

            for (int i = 0; i < tape.ListOfCylinders.Count; i++)
            {
                Ellipse ellipse = new Ellipse
                {
                    Height = tape.ListOfCylinders[i].Radius * 2,
                    Width = tape.ListOfCylinders[i].Radius * 2,
                    Stroke = Brushes.Black
                };

                Canvas.SetLeft(ellipse, tape.ListOfCylinders[i].Position.X - tape.ListOfCylinders[i].Radius);
                Canvas.SetTop(ellipse, tape.ListOfCylinders[i].Position.Y - tape.ListOfCylinders[i].Radius);

                Canvas1.Children.Add(ellipse);
            }

            Max1.Content = maxNumber.ToString();
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
