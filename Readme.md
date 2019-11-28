# Práctica FDV

## Técnicas 

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
