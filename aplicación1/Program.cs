using System;

namespace aplicación1
{
    public class Program
    {
        private static ManipuladorDatos manipuladorDatos;

        public static void Main(string[] args)
{
    var conexionMongo = new ConexionMongo();
    var personasCollection = conexionMongo.GetPersonasCollection();
    var manipuladorDatos = new ManipuladorDatos(personasCollection);

    bool running = true;
    while (running)
    {
        Console.WriteLine("Seleccione una opción:");
        Console.WriteLine("1. Listar todas las personas");
        Console.WriteLine("2. Listar cédulas por rol");
        Console.WriteLine("3. Cambiar rol de una persona");
        Console.WriteLine("4. Eliminar una persona");
        Console.WriteLine("5. Salir");

        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                ListarPersonas(manipuladorDatos);
                break;
            case "2":
                ListarCedulasPorRol(manipuladorDatos);
                break;
            case "3":
                CambiarRolPersona(manipuladorDatos);
                break;
            case "4":
                EliminarPersona(manipuladorDatos);
                break;
            case "5":
                running = false;
                break;
            default:
                Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                break;
        }

        Console.WriteLine();
    }
}

static void ListarPersonas(ManipuladorDatos manipuladorDatos)
{
    var personas = manipuladorDatos.ObtenerTodasLasPersonas();

    Console.WriteLine("Listado de todas las personas:");
    foreach (var persona in personas)
    {
        Console.WriteLine($"Cédula: {persona.Cedula}, Nombre: {persona.Nombre}, Rol: {persona.Rol}");
    }
}

static void ListarCedulasPorRol(ManipuladorDatos manipuladorDatos)
{
    Console.WriteLine("Ingrese el rol:");
    var rol = Console.ReadLine();

    var cedulas = manipuladorDatos.ObtenerCedulasPorRol(rol);

    Console.WriteLine($"Listado de cédulas con el rol '{rol}':");
    foreach (var cedula in cedulas)
    {
        Console.WriteLine($"Cédula: {cedula}");
    }
}

static void CambiarRolPersona(ManipuladorDatos manipuladorDatos)
{
    Console.WriteLine("Ingrese la cédula de la persona:");
    var cedula = Console.ReadLine();

    Console.WriteLine("Ingrese el nuevo rol:");
    var nuevoRol = Console.ReadLine();

    var resultado = manipuladorDatos.CambiarRolPersona(cedula, nuevoRol);

    if (resultado)
    {
        Console.WriteLine("El rol ha sido cambiado exitosamente.");
    }
    else
    {
        Console.WriteLine("No se encontró una persona con la cédula especificada.");
    }
}

static void EliminarPersona(ManipuladorDatos manipuladorDatos)
{
    Console.WriteLine("Ingrese la cédula de la persona:");
    var cedula = Console.ReadLine();

    var resultado = manipuladorDatos.EliminarPersona(cedula);

    if (resultado)
    {
        Console.WriteLine("La persona ha sido eliminada exitosamente.");
    }
    else
    {
        Console.WriteLine("No se encontró una persona con la cédula especificada.");
    }
}

    }
}
