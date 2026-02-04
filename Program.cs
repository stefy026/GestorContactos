using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorContactos
{
  
    /// La Clase principal del programa es la Interfaz de usuario
   
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Sistema de Gestión de Contactos";
            GestorContactos gestor = new GestorContactos();
            bool salir = false;

            MostrarBienvenida();

            while (!salir)
            {
                MostrarMenu();
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarNuevoContacto(gestor);
                        break;
                    case "2":
                        gestor.ListarContactos();
                        break;
                    case "3":
                        BuscarContacto(gestor);
                        break;
                    case "4":
                        EditarContacto(gestor);
                        break;
                    case "5":
                        EliminarContacto(gestor);
                        break;
                    case "6":
                        salir = true;
                        MostrarDespedida();
                        break;
                    default:
                        Console.WriteLine("\n Opción inválida. Intente nuevamente.");
                        break;
                }

                if (!salir)
                {
                    Console.WriteLine("\n Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

      
        /// Mostramos el mensaje de bienvenida
      
        static void MostrarBienvenida()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                                      ║");
            Console.WriteLine("║           SISTEMA DE GESTIÓN DE CONTACTOS            ║");
            Console.WriteLine("║           Programación Orientada a Objetos           ║");
            Console.WriteLine("║                                                      ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine("\n Presione cualquier tecla para comenzar...");
            Console.ReadKey();
        }

        /// Mostramos el menú principal
       
        static void MostrarMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("╔══════════════════════════════════════════════════════╗");
            Console.WriteLine("║                    MENÚ PRINCIPAL                    ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine("\n   1.   Agregar nuevo contacto");
            Console.WriteLine("   2.   Listar todos los contactos");
            Console.WriteLine("   3.   Buscar contacto");
            Console.WriteLine("   4.   Editar contacto");
            Console.WriteLine("   5.   Eliminar contacto");
            Console.WriteLine("   6.   Salir");
            Console.ForegroundColor= ConsoleColor.DarkMagenta;
            Console.WriteLine("\n════════════════════════════════════════════════════════");
            Console.ResetColor();
            Console.Write("\n Seleccione una opción: ");
        }

        
        /// Método para agregar un nuevo contacto
  
        static void AgregarNuevoContacto(GestorContactos gestor)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╔══════════════════════════════════════════════════════╗");
            Console.WriteLine("║              AGREGAR NUEVO CONTACTO                  ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════╝");
            Console.ResetColor();

            try
            {
                Console.Write("\nNombre completo: ");
                string nombre = Console.ReadLine();

                Console.Write("Número de teléfono: ");
                string telefono = Console.ReadLine();

                Console.Write("Correo electrónico: ");
                string email = Console.ReadLine();

                Console.Write("Dirección: ");
                string direccion = Console.ReadLine();

                gestor.AgregarContacto(nombre, telefono, email, direccion);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\n Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n Error inesperado: {ex.Message}");
            }
        }
       
        /// Método para buscar contactos
      
        static void BuscarContacto(GestorContactos gestor)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("╔══════════════════════════════════════════════════════╗");
            Console.WriteLine("║                 BUSCAR CONTACTO                      ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════╝");
            Console.ResetColor();

            Console.Write("\nIngrese el nombre a buscar: ");
            string nombre = Console.ReadLine();

            gestor.BuscarContacto(nombre);
        }

        /// Método para editar un contacto
      
        static void EditarContacto(GestorContactos gestor)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("╔══════════════════════════════════════════════════════╗");
            Console.WriteLine("║                 EDITAR CONTACTO                      ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════╝");
            Console.ResetColor();

            try
            {
                Console.Write("\nIngrese el ID del contacto a editar: ");
                int id = int.Parse(Console.ReadLine());

                gestor.EditarContacto(id);
            }
            catch (FormatException)
            {
                Console.WriteLine("\n Debe ingresar un número válido.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n Error: {ex.Message}");
            }
        }

        /// Método para eliminar un contacto
    
        static void EliminarContacto(GestorContactos gestor)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("╔══════════════════════════════════════════════════════╗");
            Console.WriteLine("║                ELIMINAR CONTACTO                     ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════╝");
            Console.ResetColor();

            try
            {
                Console.Write("\n Ingrese el ID del contacto a eliminar: ");
                int id = int.Parse(Console.ReadLine());

                gestor.EliminarContacto(id);
            }
            catch (FormatException)
            {
                Console.WriteLine("\n Debe ingresar un número válido.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n Error: {ex.Message}");
            }
        }

        //Mostramos el mensaje de despedida
        static void MostrarDespedida()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("╔══════════════════════════════════════════════════════╗");
            Console.WriteLine("║            ¡Gracias por usar el sistema!             ║");
            Console.WriteLine("║                   Hasta pronto                       ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════╝");
            Console.ResetColor();
        }
    }
}
