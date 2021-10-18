## TpPrograWeb3

# 1. Objetivo
Este documento describe el alcance funcional y los requisitos técnicos del trabajo práctico de la
materia Programación Web III.
# 2. Equipo
El equipo para realizar el trabajo práctico deberá ser de 4 alumnos
#3. Requisitos Técnicos
#3.1 Proyecto .NET
1. El trabajo práctico deberá ser realizado utilizando Net 5, MVC y Entity Framework Core 5.
#3.2 Base de Datos
1. Se deberá utilizar Sql Server (como mínimo 2008 Express).
2. La cátedra proveerá el script de Base de Datos con las tablas y se debe usar para el TP.
En caso de que consideren que falta algo o que no cumple con alguna funcionalidad
requerida, consultar a los profesores.
#3. Se adjunta diagrama ( ver 5.17 Diagrama de Tablas )
#3.3 Estilos
1. No se permitirán que se utilicen los estilos ya provistos por Microsoft en la aplicación de
ejemplo que provee Visual Studio.
2. Todos los archivos .css deberán estar dentro de una carpeta.
3. No utilizar estilos inline (atributo style=””) ni definir estilos dentro de una pagina (tags
<style>).
4. Debe de utilizarse algún framework/biblioteca de hojas de estilo. Algunos ejemplos:
a. Twitter Bootstrap (http://getbootstrap.com/ , temas http://bootswatch.com/ )
b. Foundation (http://foundation.zurb.com/docs/)
c. KickStart (http://www.99lime.com/elements/ )
d. Bulma (http://bulma.io/ )
e. Otro definido por los alumnos y validado con el cuerpo docente.
4/13
Universidad Nacional de la Matanza - DIIT
Tecnicatura en Programación Web - Programación Web 3 2021-2C
#3.4 JavaScript
1. No utilizar JavaScript inline dentro de una página, se deberá referenciar a archivos js.
2. Todos los archivos .js deberán estar dentro de una carpeta.
a. Si se decide utilizar algún js que no es propio, el mismo deberá estar dentro de una
subcarpeta.
3. Se deberá utilizar Bundle and minification
(https://docs.microsoft.com/es-es/aspnet/core/client-side/bundling-and-minification?view=a
spnetcore-5.0 )
Recomendaciones
Las funciones específicas de una página, deberían estar en un archivo .js con el mismo nombre
de la página
.
Aquellas funciones utilizadas en más de una página, deberían de estar dentro de otro archivo .js
de uso común.
#3.5 HTML
1. No utilizar tags table para organizar el contenido de una página en columnas, los tags
table solo están permitidos para representar una grilla/listado de información.
2. Se requiere el uso de Layouts para estructurar los formularios web de la aplicación.
Dentro del BaseLayout deberán referenciarse las hojas de estilo y archivos de javascript
de uso común por toda la aplicación.
3. Debe utilizarse HTML5.
#3.6 Validación
1. Utilizar validaciones tanto del lado del cliente como del lado del servidor.
2. Se puede utilizar una lista que detalle todos los campos que no cumplieron con las
validaciones.
3. Para todos los campos validar que la cantidad de caracteres ingresados no exceda el
límite impuesto en la base de datos.
3.7 Arquitectura y Consideraciones de Desarrollo
1. La capa de acceso a datos deberá ser realizada con Entity Framework. Este componente
de .NET será explicado en clases a fin de que los alumnos comprendan cómo utilizarlo.
5/13
Universidad Nacional de la Matanza - DIIT
Tecnicatura en Programación Web - Programación Web 3 2021-2C
2. La capa Web deberá ser realizada utilizando MVC.
3. Deberán crear un repositorio privado en Github que deberá ser compartido con los
profesores (usuarios pablokuko, matipazw, juizmariano) y donde irán subiendo los
avances
4. Utilizar la menor cantidad posible de código en los /Controllers/[Entidad]Controller, e
intentar que en los mismos haya llamadas a métodos dentro de otro proyecto que
contenga las reglas de negocio.
5. Compatibilidad con exploradores.
a. Google Chrome (la última versión para Windows).
6. Todos los borrados a través del sistema deben ser borrados lógicos. No se elimina el
registro de la base de datos, sino que se completan los campos FechaBorrado y
BorradoPor.
7. A modo de auditoria deben también guardar la fecha de modificación y creación así como
también el id del usuario.
#4. Objetivo del Proyecto
El objetivo del proyecto consiste en el desarrollo de un Sistema que permitirá que cocineros
registrados (ejemplo: un restaurante, un sitio de comida rápida, la casa de una persona particular,
etc.) creen eventos culinarios, exponiendo sus propias recetas para que sean evaluadas por
comensales.
Cada evento ofrecerá diferentes recetas para que los comensales elijan que desean comer.
Los comensales podrán realizar las reservas. Además, tendrán la oportunidad de comentar y
evaluar los eventos ya finalizados puntuando a los cocineros.
#4.1 Pantallas
Los diseños/maqueteado de algunas de las pantallas las pueden encontrar aquí. Son solamente
para identificar páginas y funcionalidades, es tarea de los alumnos diseñar las páginas para que
estén bonitas, pueden distribuir los campos, botones, imágenes como uds deseen mientras que
aparezcan todos los campos de los diseños.
6/13
Universidad Nacional de la Matanza - DIIT
Tecnicatura en Programación Web - Programación Web 3 2021-2C
#5. Especificación Funcional
Resumen de funcionalidad requerida:
1. Página de inicio (/default)
2. Menú específico para cada grupo
3. Registro de usuario (/registracion)
4. Login/Logout de usuario (para login /login y el logout)
Grupo Cocineros(es necesario estar logueado)
5. Crear evento de comida (/cocineros/eventos).
6. Crear recetas de cocina.(/cocineros/recetas)
7. Perfil con detalle de eventos y reservas(/cocineros/perfiles)
8. Cancelar eventos(/cocineros/cancelar.)
Grupo Comensales (es necesario estar logueado)
9. Reservar evento (/comensales/reserva)
10. Mis eventos y reservas (/comensales/reservas).
11. Puntuar y comentar eventos finalizados (/comensales/comentarios)
