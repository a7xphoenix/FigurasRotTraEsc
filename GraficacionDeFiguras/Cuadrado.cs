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
    class Cuadrado
    {
        int lado;
        public double[] Coor;
        Brush color;
        public Cuadrado(int lado , Brush color)
        {
            this.lado = lado;
            this.color = color;
        }

        public Canvas Dibujar(ref Canvas Plano, bool Tranladar = false, bool Rotar = false, bool Escalar = false, int reflexion =0)
        {
            //Crear Cuadrado
            Rectangle miCirculo = new Rectangle();
            miCirculo.Width = this.lado;
            miCirculo.Height = this.lado;
            miCirculo.Fill = color;

            //Crear canvas nuevo
            Frame miniCanvas = new Frame(Tranladar, Rotar, Escalar);
            miniCanvas.Width = this.lado;
            miniCanvas.Height = this.lado;
            miniCanvas.Children.Add(miCirculo);
            Canvas.SetLeft(miCirculo, 0);
            Canvas.SetTop(miCirculo, 0);

            //Agregar miniCanvas al plano
            Plano.Children.Add(miniCanvas);
            Canvas.SetLeft(miniCanvas, Plano.Width / 2 - this.lado/2 + this.Coor[0]);
            Canvas.SetTop(miniCanvas, Plano.Height / 2 - this.lado/2 + this.Coor[1]*-1);
            //Reflexion
            Transformar.Reflexion(miniCanvas, ref Plano, reflexion, this.Coor[0], this.Coor[1] * -1);
            return miniCanvas;
        }
    }
}
