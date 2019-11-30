# Práctica FDV

## Técnicas 

Para la práctica de ténicas se han usado versiones modificadas del "parallax" implementado en la práctica de sprites.

La primera version, es un juego donde el background se mueve y el personaje se mantiene en la misma posición saltando los obstáculos. Se ha usado el script Parallax.cs para añadir un movimiento continuo al fondo en el eje X.

El jugador "Indiana" tiene enlazado el script PlayerJump.cs, el cual reacciona al evento de saltar "espacio". Las rocas que aparecen en el mapa son despachadas por RockDispacher.cs y está enlazado a un objeto vacío el cual contiene una roca como hija para únicamente visualizar la zona donde aparecerán las rocas.

El RockDispatcher va lanzando rocas cada cierto tiempo dentro de un rango. Estas rocas son obtenidas del ObjectPooler.cs el cual pre-genera un conjunto de rocas.

Y las rocas derivan del prefab "Roca" el cual contiene el script AutoDisable.cs. Lo que las desabilita transcurrido cierto tiempo, volviendo a estar disponibles en el ObjectPooler.cs.

![](./game.gif)

Este otro apartado, muestra el uso de un Background con scroll se va moviendo con el personaje cada vez que llega al límite. El ScrollBackground.cs define este comportamiento.

![](./scroll.gif)

Por último, se ha creado un script Parallax.cs el cual aplicado a diferentes fondos con transparencias y orden de renderizado se obtiene el efecto parallax. El script permite ajustar el movimiento de los fondos relativo al de la cámara. Un valor menor implicará menor movimiento por consecuencia el objeto aparentará estar más lejos y un valor mayor, generará el efecto contrario. Como se puede ver en la siguiente ilustrasión:

![](./parallax.gif)


## Control de Cámara

Se ha usado la versión de Unity 2019.x.x la cual permite incluir el paquete Cinemachine desde el package manager
Se han creado tres cámaras virtuales:

- CM vcam A. Sigue al "Indiana A". Limitada por el gameobject vacío "ConfineRectCameraA" con Composite Collider y Box collider.
- CM vcam B. Sigue al "Indiana B" desde más cerca. Limitada por el ConfineRectCameraB
- CM vcam AB. Sique al "TargeGroup Indianas" el cual contiene a ambos indianas con pesos iguales.

Para los ruidos se ha usado en ambos casos tanto en el evento click del ratón como el de colisión con la roca un
6d Shake, en el canal Default. Todas las cámaras reaccionan al ruido por el mismo canal. 

La roca contiene un componente CinemachineCollisionImpulseSource para generar el ruido en la cámara

Scripts:
- CameraNoiseInput. Genera el ruido con el click del ratón adquiriendo el componente CinemachineImpulseSource de la MainCamera el cual es donde esta asociado este mismo script.
- SwitchCamera. Tiene una lista de las cámaras que se quiere usar para cambiar entre ellas. Y utiliza el método "MoveToTopOfPrioritySubqueue" para que la cámara activa se actualize según la cola interna. (Se ha optado por este método en vez de activar y desactivar las otras cámaras)

![](./camera.gif)
