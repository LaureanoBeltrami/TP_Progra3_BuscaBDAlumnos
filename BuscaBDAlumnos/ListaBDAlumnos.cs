namespace BuscaBDAlumnos;

public sealed class ListaBDAlumnos
{
    private readonly string _rutaBaseDatos;

    public ListaBDAlumnos(string rutaBaseDatos)
    {
        if (string.IsNullOrWhiteSpace(rutaBaseDatos))
        {
            throw new ArgumentException("La ruta de la base de alumnos no puede estar vacia.", nameof(rutaBaseDatos));
        }

        _rutaBaseDatos = rutaBaseDatos;
    }

    public Alumno? BuscarPorLegajo(int legajoBuscado)
    {
        if (legajoBuscado <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(legajoBuscado), "El legajo debe ser mayor a cero.");
        }

        using StreamReader lector = new(_rutaBaseDatos);

        string? linea = lector.ReadLine();
        int numeroLinea = 1;

        while ((linea = lector.ReadLine()) is not null)
        {
            numeroLinea++;

            if (string.IsNullOrWhiteSpace(linea))
            {
                continue;
            }

            Alumno alumno = ConvertirLineaEnAlumno(linea, numeroLinea);

            if (alumno.Legajo == legajoBuscado)
            {
                return alumno;
            }
        }

        return null;
    }

    private static Alumno ConvertirLineaEnAlumno(string linea, int numeroLinea)
    {
        string[] campos = linea.Split(';');

        if (campos.Length != 5)
        {
            throw new FormatException($"La linea {numeroLinea} debe tener 5 campos separados por punto y coma.");
        }

        if (!int.TryParse(campos[0].Trim(), out int legajo))
        {
            throw new FormatException($"El legajo de la linea {numeroLinea} no es numerico.");
        }

        return new Alumno(
            legajo,
            campos[1].Trim(),
            campos[2].Trim(),
            campos[3].Trim(),
            campos[4].Trim());
    }
}
