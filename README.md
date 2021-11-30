
# TP_Progra_Web_3

  

Proyecto hecho en ASP.NET Core basado en modelo MVC con EFCore.
El requerimiento detallado lo pueden encontrar en el siguiente [documento](https://drive.google.com/file/d/1-5hAuD1sM-wCpPftGN-Pl7SArX_YNbMx/view?usp=sharing)

## Pasos para levantar el proyecto

* Ejecutar script de base de datos desde la ruta: 
Solo creación de DB:
...TpPrograWeb3\RecetasTP\Database\Create_Database_Eng.sql

Creación + demo:
...TpPrograWeb3\RecetasTP\Database\CreateAndFill_Database_Eng.sql

**Tener en cuenta que los scripts están completamente en inglés, por ende el nombre de las entidades en los modelos varia.**

* Ejecutar el proyecto desde el Visual Studio.


  
## Integrantes
Pitarque Agustin 41588345
Teruel Pablo 32605368

## Preguntas

a. ¿Qué nota creen que deberían sacar en el tp? (1-10, donde para 7 debe estar toda la funcionalidad pedida) y ¿por qué?

- Creemos que un 8 sería justo. Porque nos esforzamos mucho y pudimos llegar a cumplir con los plazos en tiempo y forma por mas que hayamos tenido ciertos percances en el camino.



b. ¿Qué cosas creen que podrían mejorarse?

- Seguramente haya montón de cosas para hacerlas de otra forma y mejor. Por ejemplo la inyeccion de dependencias hubiese estado genial si hubieramos implementado generics en vez de crear 1 interfaz por clase para instanciar. Pero no lo pudimos resolver rapidamente y decidimos invertir el tiempo en las otras tareas.
- Los estilos. Personalmente me hubiese gustado que quede mejor skineada la web con un tema oscuro etc. Pero como bien dijimos en el punto pasado, nos enfocamos mucho mas a la funcionalidad que era lo que mas se iba a evaluar y mas siendo solamente 2 personas.



c. ¿Qué les resultó más complicado?

- Personalmente creo que el data binding y la cración de viewModels es un poco complicada al principio hasta que le agarrás la mano. Después como todo, se vuelve fácil de implementar y necesario.
- El tema de las vistas (frontend y como manejan los datos). Una vez que te acostumbras ya está igual pero costo. Me hubiera gustado resolver el front con otra tecnología ej React y ver como se integran.
- Algunas consultas SQL resultaron medias tediosas para usarlas en linq, como por ejemplo los group by.
