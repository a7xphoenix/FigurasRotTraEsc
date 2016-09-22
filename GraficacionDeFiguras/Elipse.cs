﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GraficacionDeFiguras
{
    public class Elipse
    {
        int a,b;
        public double[] Coor;
        SolidColorBrush color;
        public Elipse(int a ,int b, SolidColorBrush color)
        {
            this.a = a;
            this.b = b;
            this.color = color;
        }

        public Canvas Dibujar(ref Canvas Plano)
        {
            //Crear Circulo
            Ellipse miElipse = new Ellipse();
            miElipse.Width = a;
            miElipse.Height = b;
            miElipse.Fill = color;

            //Crear canvas nuevo
            Frame miniCanvas = new Frame();
            miniCanvas.Width = a;
            miniCanvas.Height = b;
            miniCanvas.Children.Add(miElipse);
            Canvas.SetLeft(miElipse, 0);
            Canvas.SetTop(miElipse, 0);

            //Agregar miniCanvas al plano
            Plano.Children.Add(miniCanvas);
            Canvas.SetLeft(miniCanvas, Plano.Width / 2 - (this.a/2)  + this.Coor[0]);
            Canvas.SetTop(miniCanvas, Plano.Height / 2  -(this.b/2)+ this.Coor[1] * -1);

            return miniCanvas;
        }
    }
}