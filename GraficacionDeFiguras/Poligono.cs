using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GraficacionDeFiguras
{
    public class Poligono
    {
        int radio;
        int lados;
        public double[] Coor;
        private PointCollection puntos = new PointCollection();
        Brush color;
        public Poligono(int radio , int lados , Brush color)
        {
            this.radio = radio;
            this.lados = lados;
            this.color = color;
            
        }


        public Canvas Dibujar(ref Canvas Plano, bool Tranladar = false, bool Rotar = false, bool Escalar = false)
        {
            //Crear canvas nuevo
            Frame miniCanvas = new Frame(Tranladar, Rotar, Escalar);
            miniCanvas.Width = this.radio * 2;
            miniCanvas.Height = this.radio * 2;
          
            CalcularPuntos(miniCanvas.Width / 2, miniCanvas.Height / 2);

             //Crear Poligono
             Polygon poligono = new Polygon();
            poligono.Stroke = color;//esto es para el contorno
            poligono.Fill = color;
            poligono.StrokeThickness = 1;
            poligono.HorizontalAlignment = HorizontalAlignment.Left;
            poligono.VerticalAlignment = VerticalAlignment.Center;
            poligono.Points = puntos;

            //Agregar poligono al canvas 
            miniCanvas.Children.Add(poligono);
            Canvas.SetLeft(poligono, 0);
            Canvas.SetTop(poligono, 0);


            //Agregar miniCanvas al plano
            Plano.Children.Add(miniCanvas);
            Canvas.SetLeft(miniCanvas, Plano.Width / 2 - this.radio + this.Coor[0]);
            Canvas.SetTop(miniCanvas, Plano.Height / 2 - this.radio + this.Coor[1]*-1);
           
            return miniCanvas;
        }
        //calcula los puntos de cada arista
        private void CalcularPuntos(double centroX , double centroY)
        {
            float PI = (float)Math.PI;
            float a = PI / 2 - PI / lados;
            int x1 = (int)(centroX - radio * Math.Cos(a));
            int y1 = (int)(centroX + radio * Math.Sin(a));
            puntos.Add(new Point(x1, y1));
            for (int j = 2; j <= lados + 1; j++)
            {
                a = a + 2 * PI / lados;
                int x2 = (int)(centroX - radio * Math.Cos(a));
                int y2 = (int)(centroX + radio * Math.Sin(a));
                puntos.Add(new Point(x2, y2));
                x1 = x2;
                y1 = y2;


            }
        }






    }
}
