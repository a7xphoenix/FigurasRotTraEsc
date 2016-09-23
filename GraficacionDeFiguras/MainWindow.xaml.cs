using ScreenServerWPF.Figuras;
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


namespace GraficacionDeFiguras
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Plano nuevoPlano = new Plano();
        public MainWindow()
        {
            InitializeComponent();
            nuevoPlano.Show();
          
        }

        private void btnIniciar_Click(object sender, RoutedEventArgs e)
        {
            bool[] Conf = new bool[3];
            Conf[0] = (bool)chboxTransportar.IsChecked;
            Conf[1] = (bool)chboxRotar.IsChecked;
            Conf[2] = (bool)chboxEscalar.IsChecked;
            BrushConverter b = new BrushConverter();
            switch (cboxTipo.Text)
            {
                case "Circulo":
                    Circulo circulo = new Circulo(int.Parse(txtRadio.Text),(Brush)b.ConvertFromString(Colores.NuevoColor()));
                    circulo.Coor = new double[] { int.Parse(txtXo.Text), int.Parse(txtYo.Text) };
                    circulo.Dibujar(ref nuevoPlano.canvasCoor, Conf[0], Conf[1], Conf[2], Reflexion());
                    break;
                case "Cuadrado":
                    Cuadrado cuadrado = new Cuadrado(int.Parse(txtA.Text), (Brush)b.ConvertFromString(Colores.NuevoColor()));
                    cuadrado.Coor = new double[] { int.Parse(txtXo.Text), int.Parse(txtYo.Text) };
                    cuadrado.Dibujar(ref nuevoPlano.canvasCoor, Conf[0], Conf[1], Conf[2], Reflexion());
                    break;
                case "Poligono":
                    Poligono poligono = new Poligono(int.Parse(txtRadio.Text),int.Parse(txtLados.Text), (Brush)b.ConvertFromString(Colores.NuevoColor()));
                    poligono.Coor = new double[] { int.Parse(txtXo.Text), int.Parse(txtYo.Text) };
                    poligono.Dibujar(ref nuevoPlano.canvasCoor, Conf[0], Conf[1], Conf[2], Reflexion());
                    break;
                case "Elipse":
                    Elipse Elipse = new Elipse(int.Parse(txtA.Text), int.Parse(txtB.Text), (Brush)b.ConvertFromString(Colores.NuevoColor()));
                    Elipse.Coor = new double[] { int.Parse(txtXo.Text), int.Parse(txtYo.Text) };
                    Elipse.Dibujar(ref nuevoPlano.canvasCoor, Conf[0], Conf[1], Conf[2], Reflexion());
                    break;
            }

            //nuevoPlano.ShowDialog();
        }

        private void btnDeshacer_Click(object sender, RoutedEventArgs e)
        {
            int indice = -1;
            for (int i = nuevoPlano.canvasCoor.Children.Count -1 ; i >= 0; i++)
            {
                if(nuevoPlano.canvasCoor.Children[i] is Frame)
                {
                    indice = i;
                    break;
                }
            }

            if(indice > -1)
                nuevoPlano.canvasCoor.Children.RemoveAt(indice);
        }

        private int Reflexion()
        {
            if (chboxReX.IsChecked == true && chboxReY.IsChecked == true && chboxReO.IsChecked == true)
                return 4;
            else if (chboxReX.IsChecked == true)
                return 1;
            else if (chboxReY.IsChecked == true)
                return 2;
            else if (chboxReO.IsChecked == true)
                return 3;
            else
                return 0;
        }
    }
}
