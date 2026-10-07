using System;

namespace MinimizacionMetodoGrafico
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("PROGRAMA DE MINIMIZACION DE COSTOS (Z)");
            Console.WriteLine("Función a minimizar: Z= 15*x1 + 20*x2\n");

            // Matriz con los puntos vértices (x1, x2) calculados en el método gráfico
            // Punto A: (0, 6)
            // Punto B: (2, 4)
            // Punto C: (6, 2)
            string[] nombresPuntos= {"A", "B", "C"};
            double[,] vertices= {
                { 0, 6 },
                { 2, 4 },
                { 6, 2 }
            };
            double mejorZ= double.MaxValue;
            string mejorPunto= "";
            double mejorX1= 0;
            double mejorX2= 0;

            Console.WriteLine("EVALUACIÓN DE PUNTOS VÉRTICES");
            // Evaluar los puntos
            for (int i= 0; i < nombresPuntos.Length; i++)
            {
                string nombre= nombresPuntos[i];
                double x1= vertices[i, 0];
                double x2= vertices[i, 1];

            // Ver si cumple con las 3 restricciones
                bool esFactible= EvaluarRestricciones(x1, x2);

                if (esFactible)
                {
                    double z= CalcularZ(x1, x2);
                    Console.WriteLine($"Punto {nombre} ({x1}, {x2}): Factible | Z= 15({x1}) + 20({x2})= {z}");

            // Minimización
                    if (z < mejorZ)
                    {
                        mejorZ= z;
                        mejorPunto= nombre;
                        mejorX1= x1;
                        mejorX2= x2;
            
                    }
                }
                else
                {
                    Console.WriteLine($"Punto {nombre} ({x1}, {x2}): No cumple las restricciones");
                }
            }

            // Resultado óptimo
            Console.WriteLine("RESULTADO ÓPTIMO");
            if (mejorZ != double.MaxValue)
            {
                Console.WriteLine($"El valor MÍNIMO de Z es: {mejorZ}");
                Console.WriteLine($"Se alcanza en el Punto {mejorPunto}: x1= {mejorX1}, x2= {mejorX2}");
            }
            // Pausa para que la consola no se cierre inmediatamente
            Console.WriteLine("\nPresiona una tecla para salir...");
            Console.ReadKey();
        }

            // Validar las restricciones del problema
        static bool EvaluarRestricciones(double x1, double x2)
        {
            // Restricción 1: x1 + 2*x2 >= 10
            bool r1= (x1 + 2 * x2) >= 10;

            // Restricción 2: 2*x1 - 3*x2 <= 6
            bool r2= (2 * x1 - 3 * x2) <= 6;

            // Restricción 3: x1 + x2 >= 6
            bool r3= (x1 + x2) >= 6;

            return r1 && r2 && r3;
        }

            // Calcular la función objetivo Z
        static double CalcularZ(double x1, double x2)
        {
            return (15 * x1) + (20 * x2);
        }
    }
}
