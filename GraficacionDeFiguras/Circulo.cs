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
    class Circulo
    {
        int radio;
        public double[] Coor;
        public Circulo(int radio)
        {
            this.radio = radio;
        }

        public Canvas Dibujar(ref Canvas Plano)
        {
            //Crear Circulo
            Ellipse miCirculo = new Ellipse();
            miCirculo.Width = this.radio * 2;
            miCirculo.Height = this.radio * 2;
            miCirculo.Fill = new SolidColorBrush(Colors.Blue);

            //Crear canvas nuevo
            Frame miniCanvas = new Frame();
            miniCanvas.Width = this.radio * 2;
            miniCanvas.Height = this.radio * 2;
            miniCanvas.Children.Add(miCirculo);
            Canvas.SetLeft(miCirculo, 0);
            Canvas.SetTop(miCirculo, 0);

            //Agregar miniCanvas al plano
            Plano.Children.Add(miniCanvas);
            Canvas.SetLeft(miniCanvas, Plano.Width / 2 - this.radio + this.Coor[0]);
            Canvas.SetTop(miniCanvas, Plano.Height / 2 - this.radio + this.Coor[1]);

            return miniCanvas;
        }
    }
}
