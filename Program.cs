using System;

namespace Ejercicio2_CilindroNeumatico
{
    /// <summary>
    /// Clase que representa el funcionamiento físico de un cilindro neumático.
    /// </summary>
    public class CilindroNeumatico
    {
        // PROPIEDADES DE LA CLASE
        public double PresionKPa { get; set; }       // Presión ingresada en kiloPascals (kPa)
        public double AreaCm2 { get; set; }          // Área del pistón ingresada en cm²
        public double FuerzaMinimaRequerida { get; set; } // Requerimiento mínimo de fuerza en Newtons (N)

        /// <summary>
        /// Constructor de la clase CilindroNeumatico.
        /// </summary>
        public CilindroNeumatico(double presionKPa, double areaCm2, double fuerzaMinima)
        {
            PresionKPa = presionKPa;
            AreaCm2 = areaCm2;
            FuerzaMinimaRequerida = fuerzaMinima;
        }

        /// <summary>
        /// Método de conversión: convierte la presión de kPa a Pascals (Pa).
        /// </summary>
        public double ConvertirPresionAPascal()
        {
            return PresionKPa * 1000.0;
        }

        /// <summary>
        /// Método de conversión: convierte el área de cm² a m².
        /// </summary>
        public double ConvertirAreaAMetrosCuadrados()
        {
            return AreaCm2 / 10000.0;
        }

        /// <summary>
        /// Método para calcular la fuerza ejercida por el pistón F = P * A.
        /// </summary>
        /// <returns>Fuerza producida en Newtons (N)</returns>
        public double CalcularFuerza()
        {
            double presionPa = ConvertirPresionAPascal();
            double areaM2 = ConvertirAreaAMetrosCuadrados();
            return presionPa * areaM2;
        }

        /// <summary>
        /// Método que evalúa si la fuerza producida cumple el requerimiento mínimo.
        /// </summary>
        public bool CumpleRequerimiento()
        {
            return CalcularFuerza() >= FuerzaMinimaRequerida;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("====================================================");
            Console.WriteLine("  EJERCICIO 2: FUERZA EN CILINDRO NEUMÁTICO");
            Console.WriteLine("====================================================\n");

            // Lectura y validación de la presión en kPa
            double presion;
            Console.Write("Ingrese la presión de trabajo (kPa): ");
            while (!double.TryParse(Console.ReadLine(), out presion) || presion < 0)
            {
                Console.Write("Entrada no válida. Ingrese una presión positiva en kPa: ");
            }

            // Lectura y validación del área efectiva en cm²
            double area;
            Console.Write("Ingrese el área efectiva del pistón (cm²): ");
            while (!double.TryParse(Console.ReadLine(), out area) || area <= 0)
            {
                Console.Write("Entrada no válida. El área debe ser un número positivo (cm²): ");
            }

            // Lectura de la fuerza mínima requerida en Newtons
            double fuerzaMinima;
            Console.Write("Ingrese la fuerza mínima requerida (N): ");
            while (!double.TryParse(Console.ReadLine(), out fuerzaMinima) || fuerzaMinima < 0)
            {
                Console.Write("Entrada no válida. Ingrese una fuerza en Newtons (N): ");
            }

            // INSTANCIACIÓN DEL OBJETO
            CilindroNeumatico cilindro = new CilindroNeumatico(presion, area, fuerzaMinima);

            // Salida de resultados convertidos y calculados con unidades explícitas
            Console.WriteLine("\n---------------- RESULTADOS ----------------");
            Console.WriteLine($"Presión Convertida:    {cilindro.ConvertirPresionAPascal():N2} Pa");
            Console.WriteLine($"Área Convertida:       {cilindro.ConvertirAreaAMetrosCuadrados():F6} m²");
            Console.WriteLine($"Fuerza Calculada:      {cilindro.CalcularFuerza():F2} N");

            if (cilindro.CumpleRequerimiento())
            {
                Console.WriteLine($"Estado: Cumple el requerimiento mínimo de {cilindro.FuerzaMinimaRequerida:F2} N.");
            }
            else
            {
                Console.WriteLine($"Estado: NO cumple el requerimiento mínimo de {cilindro.FuerzaMinimaRequerida:F2} N.");
            }
            Console.WriteLine("--------------------------------------------");
        }
    }
}