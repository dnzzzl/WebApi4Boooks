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
