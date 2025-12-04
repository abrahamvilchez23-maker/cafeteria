using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exament3
{
// Creación del menú principal
// Creación del menú principal
    class Cafeteria
    {
        static string[] nombresCombos = { "Café + Pan", "Jugo + Sándwich", "Té + Galletas" };
        static double[] preciosCombos = { 3.50, 5.00, 2.75 };
        // Uso de matriz bidimensional
        static string[,] estudiantes = new string[2, 20];
        static int[,] combos = new int[2, 20];

        static void Main(string[] args)
        {
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("SISTEMA DE RESERVAS - CAFETERÍA");
                Console.WriteLine("1. Mostrar menú");
                Console.WriteLine("2. Registrar reserva");
                Console.WriteLine("3. Cancelar reserva");
                Console.WriteLine("4. Listar reservas por turno");
                Console.WriteLine("5. Reporte de ingresos");
                Console.WriteLine("6. Buscar reserva");
                Console.WriteLine("0. Salir");
                Console.Write("Opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1: MostrarMenu(); break;
                    case 2: RegistrarReserva(); break;
                    case 3: CancelarReserva(); break;
                    case 4: ListarReservas(); break;
                    case 5: MostrarReporte(); break;
                    case 6: BuscarReserva(); break;
                }

                Console.WriteLine("Presione ENTER para continuar...");
                Console.ReadLine();

            } while (opcion != 0);
        }

        static void MostrarMenu()
        {
            Console.WriteLine("\nMENÚ DE COMBOS");
            for (int i = 0; i < nombresCombos.Length; i++)
                Console.WriteLine($"{i + 1}. {nombresCombos[i]} - S/. {preciosCombos[i]}");
        }

        static bool TurnoLleno(int turno)
        {
            int contador = 0;
            for (int i = 0; i < 20; i++)
                if (estudiantes[turno, i] != null)
                    contador++;

            return contador >= 20;
        }
        // Registro de reservas
        static void RegistrarReserva()
        {
            Console.Write("Turno (0 = Mañana | 1 = Tarde): ");
            int turno = int.Parse(Console.ReadLine());

            if (TurnoLleno(turno))
            {
                Console.WriteLine("No hay cupos disponibles en este turno.");
                return;
            }

            Console.Write("Nombre del estudiante: ");
            string nombre = Console.ReadLine();

            MostrarMenu();
            Console.Write("Seleccione combo: ");
            int combo = int.Parse(Console.ReadLine()) - 1;

            for (int i = 0; i < 20; i++)
            {
                if (estudiantes[turno, i] == null)
                {
                    estudiantes[turno, i] = nombre;
                    combos[turno, i] = combo;
                    Console.WriteLine("Reserva registrada correctamente.");
                    break;
                }
            }
        }
        // Cancelación de reservas
        static void CancelarReserva()
        {
            Console.Write("Nombre del estudiante a cancelar: ");
            string nombre = Console.ReadLine();

            for (int t = 0; t < 2; t++)
            {
                for (int i = 0; i < 20; i++)
                {
                    if (estudiantes[t, i] == nombre)
                    {
                        estudiantes[t, i] = null;
                        Console.WriteLine("Reserva cancelada.");
                        return;
                    }
                }
            }

            Console.WriteLine("No se encontró la reserva.");
        }

        static void ListarReservas()
        {
            Console.Write("Turno (0 = Mañana | 1 = Tarde): ");
            int turno = int.Parse(Console.ReadLine());

            Console.WriteLine(turno == 0 ? "\nTurno Mañana" : "\nTurno Tarde");

            for (int i = 0; i < 20; i++)
            {
                if (estudiantes[turno, i] != null)
                {
                    Console.WriteLine($"{estudiantes[turno, i]} - {nombresCombos[combos[turno, i]]}");
                }
            }
        }

        static double CalcularIngresosTurno(int turno)
        {
            double total = 0;
            for (int i = 0; i < 20; i++)
            {
                if (estudiantes[turno, i] != null)
                    total += preciosCombos[combos[turno, i]];
            }
            return total;
        }

        static void MostrarReporte()
        {
            double manana = CalcularIngresosTurno(0);
            double tarde = CalcularIngresosTurno(1);

            Console.WriteLine("Ingresos turno mañana: S/. " + manana);
            Console.WriteLine("Ingresos turno tarde: S/. " + tarde);
            Console.WriteLine("Total general: S/. " + (manana + tarde));
        }

        static void BuscarReserva()
        {
            Console.Write("Nombre a buscar: ");
            string nombre = Console.ReadLine();

            for (int t = 0; t < 2; t++)
            {
                for (int i = 0; i < 20; i++)
                {
                    if (estudiantes[t, i] == nombre)
                    {
                        string turno = t == 0 ? "Mañana" : "Tarde";
                        Console.WriteLine("Turno: " + turno);
                        Console.WriteLine("Combo: " + nombresCombos[combos[t, i]]);
                        return;
                    }
                }
            }

            Console.WriteLine("No se encontró la reserva.");
        }
    }
}







