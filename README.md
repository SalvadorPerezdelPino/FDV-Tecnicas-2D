# Técnicas 2D

## Técnicas para lograr el scroll:
1. El scroll se logra repitiendo la imagen, una a continuación de otra. Se debe prevenir que no queden espacios en blanco:
a. La cámara está fija, el fondo se va desplazando en cada frame. Se usan dos fondos. Uno de ellos lo va viendo la cámara en todo momento, el otro está preparado para el momento en que se ha avanzado hasta el punto en el que la vista de la cámara ya no abarcaría el fondo inicial. 
b. La cámara se desplaza a la derecha y el fondo está estático. Existe nuevamente un fondo de reserva que pasa a verse cuando el avance de la cámara sobrepasa el límite. El fondo anterior debe ubicarse a continuación del otro para que esté preparado. 

> Tarea: Aplicar un fondo con scroll a tu escena utilizando la técnica descrita en a.


> Tarea: Aplicar un fondo con scroll a tu escena utilizando la técnica descrita en b.


2. Desplazar el punto a partir del cual se aplica la textura. La parte sobrante se aplica en el espacio vacío.

> Tarea: Aplicar un fondo a tu escena aplicando la técnica del desplazamiento de textura.

## Efecto Parallax:
> Tarea: Aplicar efecto parallax usando la técnica de scroll en la que se mueve continuamente la posición del fondo.

> Tarea: Aplicar efecto parallax actualizando el offset de la textura.
 
> Tarea: En tu escena 2D crea un prefab que sirva de base para generar un tipo de objetos sobre los que vas a hacer un pooling de objetos que se recolectarán continuamente en tu escena. Cuando un objeto es recolectado debe pasar al pool y dejar de visualizarse. Este objeto estará disponible en el pool. En la escena, siempre que sea posible debe haber una cantidad de objetos que fijes, hasta que el número de objetos que no se han eliminado sea menor que dicha cantidad. Recuerda que para generar los objetos puedes usar el método Instantiate. Los objetos ya creados pueden estar activos o no, para ello usar SetActive. 

> Tarea: Revisa tu código de la entrega anterior e indica las mejoras que podrías hacer de cara al rendimiento.
