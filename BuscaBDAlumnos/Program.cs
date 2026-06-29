using BuscaBDAlumnos;

Console.WriteLine("BuscaBDAlumnos");
Console.WriteLine("----------------");
Console.Write("Ingrese el legajo del alumno: ");

string? entrada = Console.ReadLine();

if (!int.TryParse(entrada, out int legajo) || legajo <= 0)
{
    Console.WriteLine("Error: el legajo ingresado no es valido.");
    return;
}

try
{
    string rutaBaseDatos = Path.Combine(AppContext.BaseDirectory, "alumnos.csv");
    ListaBDAlumnos listaBDAlumnos = new(rutaBaseDatos);

    Alumno? alumno = listaBDAlumnos.BuscarPorLegajo(legajo);

    if (alumno is null)
    {
        Console.WriteLine($"No se encontro ningun alumno con legajo {legajo}.");
        return;
    }

    Console.WriteLine();
    Console.WriteLine("Alumno encontrado:");
    Console.WriteLine($"Legajo: {alumno.Legajo}");
    Console.WriteLine($"Apellido: {alumno.Apellido}");
    Console.WriteLine($"Nombre: {alumno.Nombre}");
    Console.WriteLine($"DNI: {alumno.Dni}");
    Console.WriteLine($"Email: {alumno.Email}");
}
catch (FileNotFoundException ex)
{
    Console.WriteLine($"Error: no se encontro la base de alumnos. Detalle: {ex.Message}");
}
catch (UnauthorizedAccessException ex)
{
    Console.WriteLine($"Error: no hay permisos para leer la base de alumnos. Detalle: {ex.Message}");
}
catch (IOException ex)
{
    Console.WriteLine($"Error de entrada/salida al leer la base de alumnos. Detalle: {ex.Message}");
}
catch (FormatException ex)
{
    Console.WriteLine($"Error: la base de alumnos tiene un formato invalido. Detalle: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Ocurrio un error inesperado. Detalle: {ex.Message}");
}
