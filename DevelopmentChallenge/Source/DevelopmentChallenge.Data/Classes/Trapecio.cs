using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Classes
{
    public class Trapecio : FormaGeometrica
    {

        private readonly decimal _lado;
        private readonly double _baseMayor;
        private readonly double _baseMenor;
        private readonly double _altura;

        public Trapecio(double baseMayor, double baseMenor, double altura)
        {
            _baseMayor = baseMayor;
            _baseMenor = baseMenor;
            _altura = altura;
        }
        public override string TraducirForma(int cantidad, Traducciones MiIdioma)
        {
            return cantidad == 1 ? MiIdioma.Trapecio(false) : MiIdioma.Trapecio(true);
        }
        // Método para calcular el perímetro del trapecio
        public override decimal CalcularPerimetro()
        {
            double altura = Math.Sqrt(Math.Pow((double)_lados[2], 2) - Math.Pow(((double)_lados[1] - (double)_lados[0]) / 2, 2));
            return ((_lados[0] + _lados[1]) * (decimal)altura) / 2;
        }

        // Método para calcular el área del trapecio
        public override decimal CalcularArea()
        {
            return _lados[0] + _lados[1] + _lados[2] + _lados[3];
        }
    }
}
