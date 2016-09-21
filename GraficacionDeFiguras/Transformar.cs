using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace GraficacionDeFiguras
{
    public static class Transformar
    {
        static float movX = 2;
        static float movY = 2;
        public static void Traslacion(ref Frame miCanvas, double MaxWidth, double MaxHeight)
        {
            double x1 = 0, y1 = 0;
            double x = Canvas.GetLeft(miCanvas);
            double y = Canvas.GetTop(miCanvas);
            //MessageBox.Show(x+ " " +canvasCoor.Width.ToString());
            if (miCanvas.DirHorizontal && x + miCanvas.Width < MaxWidth)
            {
                //suma
                movX = 2;
            }
            else if (!miCanvas.DirHorizontal && x > 0)
            {
                //resta
                movX = -2;
            }
            if (!miCanvas.DirVertical && y + miCanvas.Height < MaxHeight)
            {
                //suma
                movY = 2;
            }
            else if (miCanvas.DirVertical && y > 0)
            {
                //resta
                movY = -2;
            }
            if (x > MaxWidth)
                miCanvas.DirHorizontal = false;
            else if (x < 0)
                miCanvas.DirHorizontal = true;
            if (y > MaxHeight)
                miCanvas.DirVertical = true;
            else if (y <= 0)
                miCanvas.DirVertical = false;

            x1 = x + movX;
            y1 = y + movY;
            Canvas.SetLeft(miCanvas, x1);
            Canvas.SetTop(miCanvas, y1);
        }
        static RotateTransform rotateTransform1;
        public static void Rotar(ref Frame miCanvas, double angulo)
        {
            rotateTransform1 = new RotateTransform(++miCanvas.Angulo, 0.5, 0);
            //miCanvas.RenderTransform = rotateTransform1;
        }

        static ScaleTransform scaleTransform1;
        public static void Escalar(ref Frame miCanvas, double valor)
        {
            if (miCanvas.DirEscala)
            {
                miCanvas.Escala += valor;
                scaleTransform1 = new ScaleTransform(miCanvas.Escala, miCanvas.Escala);
            }
            else
            {
                miCanvas.Escala += valor;
                scaleTransform1 = new ScaleTransform(miCanvas.Escala, miCanvas.Escala);
            }
           // miCanvas.RenderTransform = scaleTransform1;
        }

        public static void Aplicar(ref Frame miCanvas)
        {
            TransformGroup myTransformGroup = new TransformGroup();
            myTransformGroup.Children.Add(rotateTransform1);
            myTransformGroup.Children.Add(scaleTransform1);
            miCanvas.RenderTransform = rotateTransform1;
        }
    }
}
