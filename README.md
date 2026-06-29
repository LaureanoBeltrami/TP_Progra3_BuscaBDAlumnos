# BuscaBDAlumnos

Aplicacion de consola en C# basada en `ListaBDAlumnos.cs` del repositorio de la catedra. Se conecta a una base de datos MySQL, pide un legajo por consola y muestra los datos del alumno si existe.

## Requisitos

- .NET SDK 10 o superior
- MySQL en ejecucion
- Base de datos `prog3n3`
- Tabla `alumnos` con los campos `legajo`, `nombre`, `apellido`, `email`, `carrera` y `turno`

## Como ejecutar

```bash
cd BuscaBDAlumnos
dotnet run
```

La aplicacion pide:

- Legajo del alumno a buscar.
- Usuario de MySQL. Si se presiona Enter, usa `root`.
- Contrasenia de MySQL. Si no tiene, presionar Enter.

La base configurada es `prog3n3`. Si se necesita cambiar servidor, puerto o base de datos, modificar el metodo `CrearConnectionString` en `BuscaBDAlumnos/ListaBDAlumnos.cs`.

## Archivos principales

- `BuscaBDAlumnos/ListaBDAlumnos.cs`: programa principal. Usa `using` para cerrar `MySqlConnection`, `MySqlCommand` y `MySqlDataReader`, y maneja excepciones con `try...catch`.
- `BuscaBDAlumnos/BuscaBDAlumnos.csproj`: referencia el paquete `MySql.Data`.
