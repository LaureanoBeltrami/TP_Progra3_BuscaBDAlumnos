# BuscaBDAlumnos

Aplicacion de consola en C# que busca un alumno por legajo y muestra sus datos por pantalla.

## Requisitos

- .NET SDK 10 o superior

## Como ejecutar

```bash
cd BuscaBDAlumnos
dotnet run
```

Cuando la aplicacion lo indique, ingresar un legajo. Ejemplos disponibles:

- 1001
- 1002
- 1003
- 1004
- 1005

## Archivos principales

- `Program.cs`: pide el legajo, muestra el resultado y maneja excepciones.
- `ListaBDAlumnos.cs`: lee la base de alumnos y busca por legajo usando `using` para cerrar correctamente el recurso.
- `Alumno.cs`: modelo de datos del alumno.
- `alumnos.csv`: base de alumnos de ejemplo.
