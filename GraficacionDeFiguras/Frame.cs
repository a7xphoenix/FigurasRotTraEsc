using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GraficacionDeFiguras
{
    public class Frame : Canvas
    {
        public bool DirHorizontal = true, DirVertical = true, DirEscala = true;
        double _Angulo = 0;
        double _Escala = 0;

        public Frame()
        {
            Random rnd = new Random();

            if (rnd.Next(1, 10) <= 5)
                DirHorizontal = true;
            else
                DirHorizontal = false;

            if (rnd.Next(1, 10) <= 5)
                DirVertical = true;
            else
                DirVertical = false;
        }

        public double Angulo
        {
            get
            {
                return _Angulo;
            }
            set
            {
                if (value > 360)
                    _Angulo = value - 360;
                else
                    _Angulo = value;
            }
        }

        public double Escala
        {
            get { return _Escala; }
            set
            {
                _Escala = value;

                if (_Escala == 100)
                {

                    DirEscala = false;
                }
                else if (_Escala == 0)
                {

                    DirEscala = true;
                }
            }
        }
    }
}
