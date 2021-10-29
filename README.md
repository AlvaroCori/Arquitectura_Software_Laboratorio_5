# Arquitectura_Software_Laboratorio_5
## Cadenas De Responsabilidad
### Implementación de un patrón de diseño de comportamiento.

Las cadenas de responsabilidad son una estructura que nos permite colocar niveles de condiciones en un orden jerárquico.
Lo que hace el algoritmo es buscar en un nivel una respuesta a un problema y si no se la encuentra se la pasa al siguiente nivel jerárquico y si en este nivel no se halla 
la respuesta pasa a otro.
### Implementación de Chain Of Responsability

![diagrama_de_clases](https://github.com/AlvaroCori/Arquitectura_Software_Laboratorio_5/blob/main/img/ExampleChainOfResponsibility.png)
### Elaboración propia
La interfaz da el trabajo de obligar a las clases a tener los métodos necesarios para operar en la cadena, el componente es la clase de la cual podemos obtener
otros componentes o podemos usar los contenedores para guardar contenedores más pequeños que nos permitan preguntarles si estas tienen respuesta a nuestro problema.
Cada container se preocupa si la respuesta puede ser respondida afirmativamente o sino el contenedor base puede cambiar a otro contenedor para que responda la solicitud.
El componente nos permite tener los métodos por defecto que son obligatorios de realizar, los container contienen una lista de sí mismos para buscar la solución.
La diferencia de container1, container2 con el container base es que los 2 primeros pueden tener sus parámetros especiales que serán usados para responder la pregunta.

### Problema 
El nuevo juego "Chain Of Brave" o Cadena De Valientes es un nuevo juego de estrategia que te permite comandar un ejército en el campo de batalla, este juego tiene la jugabilidad de manejar los soldados por jerarquía de grupos los cuales son: división, regimiento, batallón, compañía y sección. Cualquiera de estas jerarquías tiene una especialidad como pueden ser infantería de asalto, infantería pesada, entre otros más que serán agregados para el fin del juego como puede ser caballería blindada.

El problema comienza en el momento de como guardar secciones de infantería en una compañía, como guardar esa compañía en un batallón, agregada mente se quiere combinar las infantería de asalto con la infantería pesada para hacer menos monotomo el manejo de los grupos de soldados y lo más importante que se pidió es saber que subdivisiones de un grupo tiene ordenes de defender la posición o avanzar para un ataque. Las estructuras de una jerarquía de clases para cada grupo de soldados resulto complejo y sin completar los 3 requerimientos. La entrega temprana del juego no permite revisar el complejo código por lo que se toma la decisión de realizar una mejor estructura desde cero.

### Implementación de la solución

![diagrama_de_solucion](https://github.com/AlvaroCori/Arquitectura_Software_Laboratorio_5/blob/main/img/ChainOfBraveClassesDiagram.png)
### Elaboración propia

La solución está en aplicar una cadena de responsabilidades por las cuales podremos preguntar por niveles de responsabilidad, la interfaz de ITroopOrders guarda todas las ordenes que se preguntara
a cada grupo de soldados, Units contiene las respuestas por defecto cuando nadie pueda contestar, InfantryUnit contiene a todos los subgrupos que van a conformar InfantryUnit por ejemplo (InfantryUnit : Batallón de infantería) y este contiene (AssaultInfantry : Compañía de asalto) y (HeavyInfantry : Compañía pesada) así mismo AssaultInfantry y HeavyInfantry contienen campos especiales que informaran las capacidades que tiene tal clase. Los métodos Advance y Defense preguntaran a cada grupo si puede realizar un movimiento caso contrario se lo preguntaran a sus subgrupos para informar
que unidades están listas para entrar en combate o preparar la defensa.
