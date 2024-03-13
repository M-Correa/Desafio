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
    //Asi implemento el tema de idiomas 
    public class Traducciones
    {
        private readonly idioma _idioma;

        public Traducciones(idioma MiIdioma)
        {
            _idioma = MiIdioma;
        }

        public string Perimetro
        {
            get
            {
                switch (_idioma)
                {
                    case idioma.Castellano:
                        return "Perimetro";
                    case idioma.Ingles:
                        return "Perimeter";
                    case idioma.Italiano:
                        return "Perimetro";
                    default:
                        return "Perímetro";
                }
            }
        }
        public string Area
        {
            get
            {
                switch (_idioma)
                {
                    case idioma.Castellano:
                        return "Area";
                    case idioma.Ingles:
                        return "Area";
                    case idioma.Italiano:
                        return "Area";
                    default:
                        return "Área";
                }
            }
        }

        public string Cuadrado(bool plural = false)
        {
            switch (_idioma)
            {
                case idioma.Castellano:
                    return plural ? "Cuadrados" : "Cuadrado";
                case idioma.Ingles:
                    return plural ? "Squares" : "Square";
                case idioma.Italiano:
                    return plural ? "Quadrati" : "Quadrato";
                default:
                    return plural ? "Cuadrado" : "Cuadrados";
            }

        }

        public string Triangulo(bool plural = false)
        {
            switch (_idioma)
            {
                case idioma.Castellano:
                    return "Triángulo" + (plural ? "s" : "");
                case idioma.Ingles:
                    return "Triangle" + (plural ? "s" : "");
                case idioma.Italiano:
                    return "Triangolo" + (plural ? "i" : "");
                default:
                    return "Triángulo" + (plural ? "s" : "");
            }
        }

        public string Trapecio(bool plural = false)
        {
            switch (_idioma)
            {
                case idioma.Castellano:
                    return "Trapecio" + (plural ? "s" : "");
                case idioma.Ingles:
                    return "Trapezoid" + (plural ? "s" : "");
                case idioma.Italiano:
                    return "Trapezio" + (plural ? "i" : "");
                default:
                    return "Trapecio" + (plural ? "s" : "");
            }
        }


        public string Circulo(bool plural = false)
        {
            switch (_idioma)
            {
                case idioma.Castellano:
                    return "Círculo" + (plural ? "s" : "");
                case idioma.Ingles:
                    return "Circle" + (plural ? "s" : "");
                case idioma.Italiano:
                    return "Cerchio" + (plural ? "i" : "");
                default:
                    return "Círculo" + (plural ? "s" : "");
            }
        }
    }
}
