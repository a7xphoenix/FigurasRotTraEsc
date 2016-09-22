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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, RoutedEventArgs e)
        {
            Plano nuevoPlano = new Plano();
            switch (cboxTipo.Text)
            {
                case "Circulo":
                    Circulo circulo = new Circulo(int.Parse(txtRadio.Text),Brushes.RosyBrown);
                    circulo.Coor = new double[] { int.Parse(txtXo.Text), int.Parse(txtYo.Text) };
                    circulo.Dibujar(ref nuevoPlano.canvasCoor);
                    //Transformar.Reflexion(ref circulo.Dibujar(ref nuevoPlano.canvasCoor), ref nuevoPlano.canvas1, 1);
                    break;
                case "Cuadrado":
                    Cuadrado cuadrado = new Cuadrado(int.Parse(txtA.Text), Brushes.RosyBrown);
                    cuadrado.Coor = new double[] { int.Parse(txtXo.Text), int.Parse(txtYo.Text) };
                    cuadrado.Dibujar(ref nuevoPlano.canvasCoor);
                    break;
                case "Poligono":
                    Poligono poligono = new Poligono(int.Parse(txtRadio.Text),int.Parse(txtLados.Text), Brushes.RosyBrown);
                    poligono.Coor = new double[] { int.Parse(txtXo.Text), int.Parse(txtYo.Text) };
                    poligono.Dibujar(ref nuevoPlano.canvasCoor);
                    break;

                case "Elipse":
                    Elipse Elipse = new Elipse(int.Parse(txtA.Text), int.Parse(txtB.Text), Brushes.RosyBrown);
                    Elipse.Coor = new double[] { int.Parse(txtXo.Text), int.Parse(txtYo.Text) };
                    Elipse.Dibujar(ref nuevoPlano.canvasCoor);
                    break;
            }

            nuevoPlano.ShowDialog();
        }
    }
}
