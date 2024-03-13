/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo. 
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Classes
{
    public enum idioma { Castellano, Ingles,Italiano }
    public abstract class FormaGeometrica
    {

        public readonly decimal[] _lados;

        protected FormaGeometrica(params decimal[] lados)
        {
            _lados = lados;
        }

        public static FormaGeometrica CrearInstancia(Type tipo, params double[] lados)
        {
            if (!typeof(FormaGeometrica).IsAssignableFrom(tipo))
            {
                throw new ArgumentException("El tipo especificado no es una subclase de FormaGeometrica.", nameof(tipo));
            }

            return (FormaGeometrica)Activator.CreateInstance(tipo, lados);
        }

        public static string Imprimir(List<FormaGeometrica> formas, idioma MIidioma)
        {

            var sb = new StringBuilder();
            Traducciones miTraduccion = new Traducciones(MIidioma);
            if (!formas.Any())
            {
                if (MIidioma == idioma.Castellano)
                    sb.Append("<h1>Lista vacía de formas!</h1>");
                else
                    sb.Append("<h1>Empty list of shapes!</h1>");
            }
            else
            {
                // Hay por lo menos una forma
                // HEADER
                if (MIidioma == idioma.Castellano)
                    sb.Append("<h1>Reporte de Formas</h1>");
                else
                    // default es inglés
                    sb.Append("<h1>Shapes report</h1>");

                // Diccionario para almacenar la cantidad de veces que aparece cada tipo de forma geométrica
                Dictionary<Type, Tuple<int, FormaGeometrica>> cantidadPorTipo = new Dictionary<Type, Tuple<int, FormaGeometrica>>();

                // Diccionario para almacenar las sumatorias de áreas y perímetros de cada tipo de forma geométrica
                Dictionary<Type, Tuple<decimal, decimal>> sumatoriasPorTipo = new Dictionary<Type, Tuple<decimal, decimal>>();

                // Iterar sobre cada forma geométrica en la lista
                foreach (var forma in formas)
                {
                    // Actualizar la cantidad de veces que aparece cada tipo de forma geométrica
                    Type tipo = forma.GetType();
                    if (cantidadPorTipo.ContainsKey(tipo))
                    {
                        int total = cantidadPorTipo[tipo].Item1;
                        cantidadPorTipo[tipo] = new Tuple<int, FormaGeometrica>(total + 1, forma); ;
                    }
                    else
                        cantidadPorTipo[tipo] = new Tuple<int, FormaGeometrica>(1, forma); ;

                    // Calcular el área y el perímetro de la forma geométrica
                    decimal area = forma.CalcularArea();
                    decimal perimetro = forma.CalcularPerimetro();

                    // Actualizar las sumatorias de áreas y perímetros
                    if (sumatoriasPorTipo.ContainsKey(tipo))
                    {
                        var sumatorias = sumatoriasPorTipo[tipo];
                        sumatoriasPorTipo[tipo] = new Tuple<decimal, decimal>(sumatorias.Item1 + area, sumatorias.Item2 + perimetro);
                    }
                    else
                    {
                        sumatoriasPorTipo[tipo] = new Tuple<decimal, decimal>(area, perimetro);
                    }
                }
                int cantidadTotal = 0;
                decimal totalAreas = 0;
                decimal totalPerimetros = 0;
                foreach (var kvp in cantidadPorTipo)
                {
                    Type tipo = kvp.Key;
                    int cantidad = kvp.Value.Item1;
                    cantidadTotal += cantidad;
                    var sumatorias = sumatoriasPorTipo[tipo];
                    totalAreas += sumatorias.Item1;
                    totalPerimetros += sumatorias.Item2;
                    sb.Append(ObtenerLinea(cantidad, sumatorias.Item1, sumatorias.Item2, miTraduccion, kvp.Value.Item2));
                }
                // FOOTER
                sb.Append("TOTAL:<br/>");
                sb.Append(cantidadTotal + " " + (MIidioma == idioma.Castellano ? "formas" : "shapes") + " ");
                sb.Append(miTraduccion.Perimetro + " " + (totalPerimetros).ToString("#.##") + " ");
                sb.Append(miTraduccion.Area + " " + (totalAreas).ToString("#.##"));
            }

            return sb.ToString();

        }

        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, Traducciones MiTraduccion, FormaGeometrica miForma)
        {
            if (cantidad > 0)
            {
                return $"{cantidad} {miForma.TraducirForma(cantidad, MiTraduccion)} | {MiTraduccion.Area} {area:#.##} | {MiTraduccion.Perimetro} {perimetro:#.##} <br/>";
            }

            return string.Empty;
        }

        public abstract string TraducirForma(int cantidad, Traducciones MiTraduccion);

        public abstract decimal CalcularArea();

        public abstract decimal CalcularPerimetro();
    }
   
}
