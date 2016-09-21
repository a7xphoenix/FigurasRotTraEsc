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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace GraficacionDeFiguras
{
    /// <summary>
    /// Lógica de interacción para Plano.xaml
    /// </summary>
    public partial class Plano : Window
    {
        DispatcherTimer Timer1 = new DispatcherTimer();
        DispatcherTimer Timer3 = new DispatcherTimer();

        public Plano()
        {
            InitializeComponent();
            canvasCoor.Width = Forma.Width;
            canvasCoor.Height = Forma.Height;
            PlanoCartesiano.Dibujar(ref canvasCoor);

            //Timers
            Timer1.Tick += new EventHandler(Timer1_Tick);
            Timer1.Interval = new TimeSpan(0, 0, 0, 0, 10); // cada segundo ejecuta el metodo
            Timer1.Start();


            Timer3.Tick += new EventHandler(Timer3_Tick);
            Timer3.Interval = new TimeSpan(0, 0, 0, 1, 0); // cada segundo ejecuta el metodo
            //Timer3.Start();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //canvasCoor.Width = Forma.Width;
            //canvasCoor.Height = Forma.Height;
            //PlanoCartesiano.Dibujar(ref canvasCoor);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < canvasCoor.Children.Count; i++)
            {
                if (canvasCoor.Children[i] is Frame)
                {
                    Frame aux = (Frame)canvasCoor.Children[i];
                    Transformar.Escalar(ref aux, 0.1);
                    Transformar.Rotar(ref aux, 1);
                    Transformar.Traslacion(ref aux, canvasCoor.Width, canvasCoor.Height);
                    Transformar.Aplicar(ref aux);
                }
            }
        }

        private void Timer3_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < canvasCoor.Children.Count; i++)
            {
                if (canvasCoor.Children[i] is Frame)
                {
                    Frame aux = (Frame)canvasCoor.Children[i];
                }
            }
        }

        

        private void Forma_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
        }
    }
}
