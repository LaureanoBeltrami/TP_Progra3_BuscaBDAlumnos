/*===============================================================================

PROGRAMACION III - BuscaBDAlumnos

Basado en el ejemplo ListaBDAlumnos.cs:
https://github.com/ocantone/UTN_2026_Program_III/tree/main/Clase22_CSMySQL/ListaBDAlumnos

Antes de correr el proyecto, se debe tener instalado el driver de MySQL:
dotnet add package MySql.Data --source https://api.nuget.org/v3/index.json

Este proyecto ya incluye la referencia al paquete en BuscaBDAlumnos.csproj.

===============================================================================*/

using MySql.Data.MySqlClient;

namespace BuscaBDAlumnos;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("BUSCA BD ALUMNOS");
        Console.WriteLine("================");
        Console.Write("Ingrese el legajo del alumno: ");

        string? entrada = Console.ReadLine();

        if (!int.TryParse(entrada, out int legajo) || legajo <= 0)
        {
            MostrarError("El legajo ingresado no es valido.");
            return;
        }

        Console.WriteLine("\nIntentando conectar a la base de datos MySQL...");

        try
        {
            string connectionString = CrearConnectionString();

            using MySqlConnection conexion = new(connectionString);
            conexion.Open();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Conexion exitosa al servidor de MySQL.\n");
            Console.ResetColor();

            string consulta = """
                SELECT legajo, nombre, apellido, email, carrera, turno
                FROM alumnos
                WHERE legajo = @legajo
                """;

            using MySqlCommand comando = new(consulta, conexion);
            comando.Parameters.AddWithValue("@legajo", legajo);

            using MySqlDataReader lector = comando.ExecuteReader();

            if (!lector.Read())
            {
                MostrarError($"No se encontro ningun alumno con legajo {legajo}.");
                return;
            }

            Console.WriteLine("ALUMNO ENCONTRADO");
            Console.WriteLine("-----------------");
            Console.WriteLine($"Legajo: {lector["legajo"]}");
            Console.WriteLine($"Nombre: {lector["nombre"]}");
            Console.WriteLine($"Apellido: {lector["apellido"]}");
            Console.WriteLine($"Email: {lector["email"]}");
            Console.WriteLine($"Carrera: {lector["carrera"]}");
            Console.WriteLine($"Turno: {lector["turno"]}");
        }
        catch (MySqlException ex)
        {
            MostrarError("Ocurrio un error al intentar operar con la base de datos:");
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            MostrarError("Ocurrio un error inesperado:");
            Console.WriteLine(ex.Message);
        }
    }

    private static string CrearConnectionString()
    {
        Console.Write("Usuario MySQL (Enter para root): ");
        string? usuario = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(usuario))
        {
            usuario = "root";
        }

        Console.Write("Contrasenia MySQL (Enter si no tiene): ");
        string contrasenia = LeerContrasenia();

        MySqlConnectionStringBuilder builder = new()
        {
            Server = "127.0.0.1",
            Port = 3306,
            Database = "prog3n3",
            UserID = usuario,
            Password = contrasenia
        };

        return builder.ConnectionString;
    }

    private static string LeerContrasenia()
    {
        string contrasenia = "";
        ConsoleKeyInfo tecla;

        while ((tecla = Console.ReadKey(intercept: true)).Key != ConsoleKey.Enter)
        {
            if (tecla.Key == ConsoleKey.Backspace)
            {
                if (contrasenia.Length > 0)
                {
                    contrasenia = contrasenia[..^1];
                    Console.Write("\b \b");
                }

                continue;
            }

            contrasenia += tecla.KeyChar;
            Console.Write("*");
        }

        Console.WriteLine();
        return contrasenia;
    }

    private static void MostrarError(string mensaje)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(mensaje);
        Console.ResetColor();
    }
}
