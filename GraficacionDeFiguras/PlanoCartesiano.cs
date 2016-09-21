using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GraficacionDeFiguras
{
    static class PlanoCartesiano
    {
        public static void Dibujar(ref Canvas canvas, int Unidad = 10)
        {
            //Limpiar(ref canvas);
            double centrox = canvas.Width / 2;
            double centroy = canvas.Height / 2;
            //eje X
            Rectangle miRect = new Rectangle();
            miRect.Width = canvas.Width;
            miRect.Height = 1;
            miRect.Fill = Brushes.Red;
            Canvas.SetLeft(miRect, 0);
            Canvas.SetTop(miRect, centroy);
            canvas.Children.Add(miRect);
            //eje Y
            Rectangle miRect2 = new Rectangle();
            miRect2.Width = 1;
            miRect2.Height = canvas.Height;
            miRect2.Fill = Brushes.Red;
            Canvas.SetLeft(miRect2, centrox);
            Canvas.SetTop(miRect2, 0);
            canvas.Children.Add(miRect2);
        }

        public static void Limpiar(ref Canvas canvas)
        {
            canvas.Children.Clear();
        }

        public static void GraficarCuadricula()
        {

        }
    }
}
