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

La cadena de conexion usada es:

```text
Server=127.0.0.1;Port=3306;Database=prog3n3;Uid=root;Pwd=root;
```

Si tu MySQL usa otra clave, usuario o base de datos, modificar la constante `ConnectionString` en `BuscaBDAlumnos/ListaBDAlumnos.cs`.

## Archivos principales

- `BuscaBDAlumnos/ListaBDAlumnos.cs`: programa principal. Usa `using` para cerrar `MySqlConnection`, `MySqlCommand` y `MySqlDataReader`, y maneja excepciones con `try...catch`.
- `BuscaBDAlumnos/BuscaBDAlumnos.csproj`: referencia el paquete `MySql.Data`.
