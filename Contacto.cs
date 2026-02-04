using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorContactos
{

    /// Clase que representa un contacto con sus datos personales

    public class Contacto
    {
        // Propiedades automáticas
        public int Id { get; set; } 
        public string Nombre { get; set; } //Propiedad Encapsulada
        public string NumeroTelefono { get; set; }
        public string CorreoElectronico { get; set; }
        public string Direccion { get; set; }

        // Constructor por defecto
        public Contacto()
        {
        }

            // Constructor con parámetros
            public Contacto(int id, string nombre, string numeroTelefono, string correoElectronico, string direccion)
        {
            Id = id;
            Nombre = nombre;
            NumeroTelefono = numeroTelefono;
            CorreoElectronico = correoElectronico;
            Direccion = direccion;
        }

        // Método para mostrar la información del contacto
        public void MostrarInformacion()
        {
            Console.WriteLine($"\n╔══════════════════════════════════════════════════════╗");
            Console.WriteLine($"  ID: {Id}");
            Console.WriteLine($"  Nombre: {Nombre}");
            Console.WriteLine($"  Teléfono: {NumeroTelefono}");
            Console.WriteLine($"  Email: {CorreoElectronico}");
            Console.WriteLine($"  Dirección: {Direccion}");
            Console.WriteLine($"╚══════════════════════════════════════════════════════╝");
        }

        // Sobrescritura del método ToString
        public override string ToString()
        {
            return $"{Id}|{Nombre}|{NumeroTelefono}|{CorreoElectronico}|{Direccion}";
        }
    
        }
    }
