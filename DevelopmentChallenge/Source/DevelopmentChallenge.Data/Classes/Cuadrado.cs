using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Classes
{
    public class Cuadrado : FormaGeometrica
    {

        public Cuadrado(decimal lado) : base(lado)
        {
        }

        public override string TraducirForma(int cantidad, Traducciones MiIdioma)
        {
            return cantidad == 1 ? MiIdioma.Cuadrado(false) : MiIdioma.Cuadrado(true);
        }



        public override decimal CalcularArea()
        {
            return _lados[0] * _lados[0];
        }


        public override decimal CalcularPerimetro()
        {
            return _lados[0] * 4;
        }
    }
}
