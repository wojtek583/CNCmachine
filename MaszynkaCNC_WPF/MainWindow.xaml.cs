using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace MaszynkaCNC_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    class Punkt
    {
        public int Xpozycja;
        public int Ypozycja;
    }



    public partial class MainWindow : Window
    {

        Point currentPoint = new Point();
        List<Punkt> punkty;

        public MainWindow()
        {
            InitializeComponent();
            punkty = new List<Punkt> { new Punkt { Xpozycja = 0, Ypozycja = 0} };
        }
      
        private void Canvas_MouseDown_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                currentPoint = e.GetPosition(this);
            }
        }


        private void Canvas_MouseMove_1(object sender, System.Windows.Input.MouseEventArgs e)
        {
           

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Line line = new Line();

                line.Stroke = SystemColors.WindowFrameBrush;
                line.X1 = currentPoint.X;
                line.Y1 = currentPoint.Y;
                line.X2 = e.GetPosition(this).X;
                line.Y2 = e.GetPosition(this).Y;
                pozycjax.Content= currentPoint.X;
                pozycjaY.Content = currentPoint.Y;

                currentPoint = e.GetPosition(this);

                    paintSurface.Children.Add(line);
                if (punkty.Last().Xpozycja != currentPoint.X && punkty.Last().Ypozycja != currentPoint.Y)
                {

                punkty.Add(new Punkt { Xpozycja = (int)currentPoint.X,  Ypozycja = (int)currentPoint.Y });

                }

                



            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            paintSurface.Children.Clear();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            

            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\Users\wojte\Desktop\CNC.txt"))
            {
                foreach (var punkt in punkty)
                {
                    
                        file.WriteLine(punkt.Xpozycja + " " + punkt.Ypozycja + "\t");
                }
            }
            //if (File.Exists(@"C:\Users\wojte\Desktop\CNC.txt"))
            //{
            //    foreach (var punkt in punkty)
            //    {
            //        File.(@"C:\Users\wojte\Desktop\CNC.txt", punkt.Xpozycja + " " + punkt.Ypozycja + "\t");

            //    }

            //}


           
            MessageBox.Show("Zapisano plik");
            this.Close();
            
        }
    }
}
