# Ejercicio Web API

La solucion cuenta con dos proyectos: backend en ASP.NET Core Web Api y frontend en MVC.
Se utiliza el modulo HttpClient para hacer interfaz a traves de Interfaces RESTful Http.

# Backend: WebApi4Boooks
	- Controlador: BoooksController.cs
		-Get, post, put, delete
	- Capa de servicio por injeccion de dependencia: FakeRestHttpClient
	- Pruebas unitarias: WebApi4Boooks.http
	- Configuracion de entorno: appsettings.json

# Frontend: BoooksUI
	- Controlador: BoooksController.cs
	- UI: Bootstrap, vanilla javascript, Sweetalert.js
	- Configuracion de entorno: appsettings.json
	
# Ejecucion:
	## Opcion cargar la solucion en Visual Studio, lanzar el perfil "New Profile" con ambos proyectos.
 	## Opcion minimalista: 
```
git clone https://github.com/dnzzzl/WebApi4Boooks
cd WebApi4Boooks
dotnet run --project .\WebApi4Boooks\WebApi4Boooks.csproj
-- en ventana diferente
cd WebApi4Boooks
dotnet run --project .\BoooksSolution\BoooksUI\BoooksUI.csproj
```
![{5108E143-5DB9-4BE9-9663-CB47222FBF09}](https://github.com/user-attachments/assets/8e717e2f-5c33-4366-a413-f4a854a58ada)
![{2B94AE29-FB4F-41A0-9249-A68CBEA548F4}](https://github.com/user-attachments/assets/6fdc7311-a510-4da1-8a30-004585229325)
![{FE0D08E7-E31D-4BED-BF99-86B1009763EE}](https://github.com/user-attachments/assets/aea73208-9866-4fb4-a25e-62a5f58958e5)


