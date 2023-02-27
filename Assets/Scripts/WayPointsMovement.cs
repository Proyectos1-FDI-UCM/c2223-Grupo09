using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointsMovement : MonoBehaviour
{
    //Este script sirve para cualquier gameobject que vaya a tener una ruta determinada, se puede usar tanto para los enemigos como para plataformas

    [SerializeField]
    private Transform[] waypoints; //puntos de cambio de direcci�n

    [SerializeField] private bool LockX;

    private Vector2 siguientePosicion; //posici�n siguiente a la que se debe llegar
    private int numeroSigPosicion = 0; //contador de posiciones

    [SerializeField]
    private float distanciaCambio = 1f; //distancia entre gameobject-waypoint en la que se debe cambiar de direcci�n

    [SerializeField]
    private float velocidad; //velocidad del gameobject

    // Start is called before the first frame update
    void Start()
    {
        if (LockX)
        {
            siguientePosicion = new Vector2 (waypoints[0].position.x,transform.position.y); //se establece la primera posici�n a alcanzar sin contar la diferencia en Y
        }
        else
        {
            siguientePosicion = waypoints[0].position;  //se establece la primera posici�n a alcanzar
        }        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, siguientePosicion, velocidad * Time.deltaTime); /*el gameobject se mueve desde su posici�n hasta la siguiente
                                                                                                                     con una velocidad determinada*/

        if (Vector2.Distance(transform.position, siguientePosicion) < distanciaCambio)
        {
            numeroSigPosicion++; /*cuando la distancia entre el gameobject y la siguiente posici�n sea < 0.5f, 
                                 la siguiente posici�n cambia al siguiente elemento en el array de waypoints*/

            if (numeroSigPosicion == waypoints.Length) //si llega al final del array de waypoints, vuelve a la posici�n inicial
            {
                numeroSigPosicion = 0;
            }
            if (LockX)
            {
                siguientePosicion = new Vector2(waypoints[numeroSigPosicion].position.x, transform.position.y); //se establece la nueva posici�n sin contar la diferencia en Y
            }
            else
            {
                siguientePosicion = waypoints[numeroSigPosicion].position; //se establece la nueva posici�n
            }
        }
    }
}
