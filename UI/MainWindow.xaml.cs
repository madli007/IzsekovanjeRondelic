using Library;
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
            Canvas1.Children.Clear();
            Draw();
        }

        public void Draw()
        {
            int radius = Convert.ToInt32(TextBoxRadius.Text);
            int minDistC2C = Convert.ToInt32(TextBoxDistanceC2C.Text);
            int minDistC2Edge = Convert.ToInt32(TextBoxDistanceC2E.Text);

            Tape t = new Tape(Convert.ToInt32(TextBoxLength.Text), Convert.ToInt32(TextBoxWidth.Text));

            Rondelica r = new Rondelica(radius, minDistC2C, minDistC2Edge, new Library.Point());
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
                    Height = t.ListOfCylinders[i].Radius,
                    Width = t.ListOfCylinders[i].Radius,
                    Stroke = Brushes.Black
                };

                Canvas.SetLeft(e, t.ListOfCylinders[i].Position.X);
                Canvas.SetTop(e, t.ListOfCylinders[i].Position.Y);

                Canvas1.Children.Add(e);
            }

            Max1.Content = a.ToString();
        }
    }
}
