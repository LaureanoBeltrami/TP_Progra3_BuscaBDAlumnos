namespace BuscaBDAlumnos;

public sealed class Alumno
{
    public Alumno(int legajo, string apellido, string nombre, string dni, string email)
    {
        Legajo = legajo;
        Apellido = apellido;
        Nombre = nombre;
        Dni = dni;
        Email = email;
    }

    public int Legajo { get; }
    public string Apellido { get; }
    public string Nombre { get; }
    public string Dni { get; }
    public string Email { get; }
}
