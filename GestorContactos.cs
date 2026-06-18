using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorContactos
{
    public class GestorContactos
    {
        private List<Contacto> listaContactos;
        private int contadorId;
        private const string ARCHIVO_DATOS = "contactos.txt";

        public GestorContactos()
        {
            listaContactos = new List<Contacto>();
            contadorId = 1;
            CargarContactos();
        }


        public void AgregarContacto(string nombre, string telefono, string email, string direccion)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre no puede estar vacío");
            }

            if (string.IsNullOrWhiteSpace(telefono))
            {
                throw new ArgumentException("El número de teléfono no puede estar vacío");
            }

            Contacto nuevoContacto = new Contacto(contadorId++, nombre, telefono, email, direccion);
            listaContactos.Add(nuevoContacto);
            GuardarContactos();

            Console.WriteLine("\n ✓ Contacto agregado exitosamente!");
        }

      
        public void ListarContactos()
        {
            if (listaContactos.Count == 0)
            {
                Console.WriteLine("\n No hay contactos registrados.");
                return;
            }

            Console.WriteLine("\n════════════════ LISTA DE CONTACTOS ════════════════");
            foreach (var contacto in listaContactos)
            {
                contacto.MostrarInformacion();
            }
            Console.WriteLine($"\nTotal de contactos: {listaContactos.Count}");
        }

        public void BuscarContacto(string nombreBuscar)
        {
            var resultados = listaContactos
                .Where(c => c.Nombre.ToLower().Contains(nombreBuscar.ToLower()))
                .ToList();

            if (resultados.Count == 0)
            {
                Console.WriteLine("\n⚠ No se encontraron contactos con ese nombre.");
                return;
            }

            Console.WriteLine($"\n════════════════ RESULTADOS DE BÚSQUEDA ════════════════");
            foreach (var contacto in resultados)
            {
                contacto.MostrarInformacion();
            }
        }

     
        public void EditarContacto(int id)
        {
            Contacto contacto = listaContactos.FirstOrDefault(c => c.Id == id);

            if (contacto == null)
            {
                Console.WriteLine("\n Contacto no encontrado.");
                return;
            }

            Console.WriteLine("\n Contacto actual:");
            contacto.MostrarInformacion();

            Console.WriteLine("\n--- Ingrese los nuevos datos (Enter para mantener) ---");

            Console.Write("Nuevo nombre: ");
            string nombre = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nombre))
                contacto.Nombre = nombre;

            Console.Write("Nuevo teléfono: ");
            string telefono = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(telefono))
                contacto.NumeroTelefono = telefono;

            Console.Write("Nuevo email: ");
            string email = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(email))
                contacto.CorreoElectronico = email;

            Console.Write("Nueva dirección: ");
            string direccion = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(direccion))
                contacto.Direccion = direccion;

            GuardarContactos();
            Console.WriteLine("\n✓ Contacto actualizado exitosamente!");
        }

        public void EliminarContacto(int id)
        {
            Contacto contacto = listaContactos.FirstOrDefault(c => c.Id == id);

            if (contacto == null)
            {
                Console.WriteLine("\n Contacto no encontrado.");
                return;
            }

            contacto.MostrarInformacion();
            Console.Write("\n ¿Está seguro de eliminar este contacto? (S/N): ");
            string confirmacion = Console.ReadLine().ToUpper();

            if (confirmacion == "S")
            {
                listaContactos.Remove(contacto);
                GuardarContactos();
                Console.WriteLine("\n ✓ Contacto eliminado exitosamente!");
            }
            else
            {
                Console.WriteLine("\n Operación cancelada.");
            }
        }
       
        private void GuardarContactos()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(ARCHIVO_DATOS))
                {
                    foreach (var contacto in listaContactos)
                    {
                        sw.WriteLine(contacto.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n Error al guardar: {ex.Message}");
            }
        }
  
        private void CargarContactos()
        {
            try
            {
                if (File.Exists(ARCHIVO_DATOS))
                {
                    string[] lineas = File.ReadAllLines(ARCHIVO_DATOS);

                    foreach (string linea in lineas)
                    {
                        string[] datos = linea.Split('|');
                        if (datos.Length == 5)
                        {
                            Contacto contacto = new Contacto
                            {
                                Id = int.Parse(datos[0]),
                                Nombre = datos[1],
                                NumeroTelefono = datos[2],
                                CorreoElectronico = datos[3],
                                Direccion = datos[4]
                            };
                            listaContactos.Add(contacto);

                            if (contacto.Id >= contadorId)
                                contadorId = contacto.Id + 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n Error al cargar: {ex.Message}");
            }
        }
    }
}
