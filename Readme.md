# Prueba Tecnica - Desarrollador con Liderazgo T�cnico

Requisitos para ejecutar la aplicacion:
* .NET 8 SDK
* SQL Server Express 2019 o superior

## Ejecucion desde la terminal

 - Ingresar desde la terminal o linea de comandos a la carpeta del proyecto.
 - Ejecutar los siguientes comandos en orden:
	  2.1. dotnet restore
	  2.2. dotnet build
	  3.3. dotnet run --project Q10Enrollment/Q10Enrollment.csproj
Al ejecutar la aplicaci�n, el proyecto deber�a aplicar autom�ticamente las migraciones necesarias para crear el esquema de la base de datos.
En caso de presentar inconvenientes con la conexi�n a la base de datos, actualice la cadena de conexi�n en la clave `"Default"` dentro del archivo `appsettings.json` del proyecto `Q10Enrollment`, de acuerdo con la configuraci�n de SQL Server en su sistema.
Ejemplo de configuraci�n:
 ``` json {
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "Default": "Server=localhost\\SQLEXPRESS;Database=MyAppDb;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=True;"
  }
}``` 