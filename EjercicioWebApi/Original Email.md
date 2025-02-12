From: Edward Mata (ClaroDom) <Edward_Mata@claro.com.do>

Buenos día;
Prueba Técnica Remota

Crear Aplicación Web con BackEnd con las siguientes características:

### Backend (WebApi)
- Debe tener los siguentes endpoints (servicios):
```
                   GET                    /api/Books

                   GET                    /api/Books/{id}

                   POST                 /api/Books/

                   PUT                    /api/Books/{id}

                   Delete               /api/Books/{id}
```

- Debe retornar los HttpStatusCode según el standard de rest
- Estos endpoint debe ejecutar otro servicio rest utilizando HttpClient: `https://fakerestapi.azurewebsites.net/index.html`
- Opcional: Crear Capa de servicio para el API más arriba.
- Opcional: Crear UnitTest a backend y/o capa de servicio

Nota: El servicio es un FakeApi  por ende las actualizaciones no serán funcionales.

### Frontend (any)
- Debe Tener las siguientes funcionalidades usando el backend creado anteriormente:
                               ```
```
Listar 
Ver Detalle de Book de la lista 
Eliminar Books 
Crear Books
Editar Books
Consultar Books por ID
```
- Si la respuesta del servicio tiene status diferente de Success indicar con una alerta.
### Notas Adicionales

Los fuentes de este desarrollo deben ser publicados en un repositorio de GITHUB.
Opcional: utilizar el estándar de GitFlow para cargar los fuentes en el repositorio.

Responder este email con el URL del repositorio antes de **miércoles 12, a más tardar 4:00 PM.**
Opcional: si ha utilizado una herramienta, framework o plugins favor indicar porque lo ha utilizado.

Puede utilizar las siguientes herramientas/framework/plugins

                Reactjs

                Angular

                Blazor

                Asp.Net MVC

                Razor Pages

                Jquery, Bootstrap o Materia Design

                Asp NetCore

**No puede utilizar:**
Otro lenguaje que no sea C# para el backend
Ningún componente tipo wizard como GridView de AspNet y Scafolding de Visual Studio.

**Nota importante:**
Aun no completando todo lo requerido favor enviar el resultado que ya ha completado y se va a evaluar.