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
using System.IO;

namespace MaszynkaCNC_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Point currentPoint = new Point();

        public MainWindow()
        {
            InitializeComponent();
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

                if (File.Exists(@"C:\Users\wojte\Desktop\CNC.txt"))
                {


                    int i = 0;

                   int pozX = Convert.ToInt32(currentPoint.X);
                    int pozy = Convert.ToInt32(currentPoint.Y);
                    string[] myString = new string[800];
                    string[] myString2 = new string[800];
                    myString[i] = pozX.ToString();
                    myString2[i] = pozy.ToString();

                    File.WriteAllText(@"C:\Users\wojte\Desktop\CNC.txt", "\t"+ myString[i] +" "+ myString2[i]+"\n" );

                    i++;

               }

                
                

            //chuja nie działa -_-

                    //paintSurface.Children.Add(line);
                    //using (StreamWriter sw = new StreamWriter(@"C:\Users\wojte\Desktop\CNC.txt"))
                    //    {
                    //       do
                    //       {
                    //             sw.WriteLine(myString[pozX] + myString2[pozy]);

                    //       } while (e.LeftButton == MouseButtonState.Pressed);
                            
                    //    }




            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            paintSurface.Children.Clear();
            
        }
    }
}
