using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            if (x + miCanvas.Width > MaxWidth)
                miCanvas.DirHorizontal = false;
            else if (x < 0)
                miCanvas.DirHorizontal = true;
            if (y + miCanvas.Height > MaxHeight)
                miCanvas.DirVertical = true;
            else if (y <= 0)
                miCanvas.DirVertical = false;

            x1 = x + movX;
            y1 = y + movY;
            Canvas.SetLeft(miCanvas, x1);
            Canvas.SetTop(miCanvas, y1);
        }
        public static void Rotar(ref Frame miCanvas, double angulo)
        {
            RotateTransform rotateTransform1;
            rotateTransform1 = new RotateTransform(++miCanvas.Angulo, miCanvas.Width/2, miCanvas.Height/2);
            miCanvas.RenderTransform = rotateTransform1;
        }

        public static void Escalar(ref Frame miCanvas, double valor)
        {
        ScaleTransform scaleTransform1;
            if (miCanvas.DirEscala)
            {
                miCanvas.Escala = valor;
                scaleTransform1 = new ScaleTransform(miCanvas.Escala, miCanvas.Escala);
            }
            else
            {
                miCanvas.Escala = valor;
                scaleTransform1 = new ScaleTransform(miCanvas.Escala, miCanvas.Escala);
            }
            miCanvas.RenderTransform = scaleTransform1;
        }

        public static void Reflexion(Frame miCanvas , ref Canvas plano, int opcion , double x , double y)
        {
            Frame reflexion = new Frame();
            foreach (UIElement item in miCanvas.Children)
            {
                var xaml = System.Windows.Markup.XamlWriter.Save(item);
                var deepCopy = System.Windows.Markup.XamlReader.Parse(xaml) as UIElement;
                reflexion.Children.Add(deepCopy);
            }
            switch (opcion)
            {
                //Con respecto al eje X
                case 1:
                    Canvas.SetLeft(reflexion, plano.Width/2 + x - miCanvas.Width/2);
                    Canvas.SetTop(reflexion, plano.Height / 2 + (y *-1) - miCanvas.Height);
                    plano.Children.Add(reflexion);
                    break;
                //Con respecto al eje Y
                case 2:
                    Canvas.SetLeft(reflexion, (plano.Width / 2) - miCanvas.Width/2 + x*-1);
                    Canvas.SetTop(reflexion, (plano.Height / 2) + y - miCanvas.Height/2);
                    plano.Children.Add(reflexion);
                    break;
                    //con respecto al origen
                case 3:
                    Canvas.SetLeft(reflexion, (plano.Width / 2) - miCanvas.Width / 2 + x * -1);
                    Canvas.SetTop(reflexion, plano.Height / 2 + (y * -1) - miCanvas.Height);
                    plano.Children.Add(reflexion);
                    break;
                case 4:
                    Reflexion(miCanvas, ref plano, 1, x, y);
                    Reflexion(miCanvas, ref plano, 2, x, y);
                    Reflexion(miCanvas, ref plano, 3, x, y);
                    
                    break;
                default:
                    break;
            }
           
        }

        public static void Aplicar(ref Frame miCanvas)
        {
            //TransformGroup myTransformGroup = new TransformGroup();
            //myTransformGroup.Children.Add(rotateTransform1);
            //myTransformGroup.Children.Add(scaleTransform1);
            //miCanvas.RenderTransform = rotateTransform1;
        }
    }
}
