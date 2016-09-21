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
                    Circulo circulo = new Circulo(int.Parse(txtRadio.Text));
                    circulo.Coor = new double[] { int.Parse(txtXo.Text), int.Parse(txtYo.Text) };
                    circulo.Dibujar(ref nuevoPlano.canvasCoor);
                    break;
                case "Cuadrado":
                    Cuadrado cuadrado = new Cuadrado(int.Parse(txtA.Text));
                    cuadrado.Coor = new double[] { int.Parse(txtXo.Text), int.Parse(txtYo.Text) };
                    cuadrado.Dibujar(ref nuevoPlano.canvasCoor);
                    break;
            }

            nuevoPlano.ShowDialog();
        }
    }
}
