using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointsMovement : MonoBehaviour
{
    //Este script sirve para cualquier gameobject que vaya a tener una ruta determinada, se puede usar tanto para los enemigos como para plataformas

    [SerializeField]
    private Transform[] waypoints; //puntos de cambio de dirección

    private Vector2 siguientePosicion; //posición siguiente a la que se debe llegar
    private int numeroSigPosicion = 0; //contador de posiciones


    //SOLO se asignará en los casos en los que el enemigo vaya a detectar al jugador en un área determinada, en otro caso podría resultar en un comportamiento indeseado en los enemigos
    [SerializeField]
    private Transform player;  

    [SerializeField]
    private float distanciaCambio = 1f; //distancia entre gameobject-waypoint en la que se debe cambiar de dirección

    [SerializeField]
    private float velocidad; //velocidad del gameobject

    // Start is called before the first frame update
    void Start()
    {
        siguientePosicion = waypoints[0].position; //se establece la primera posición a alcanzar
       // player = GameObject.FindGameObjectWithTag("Player").transform;        
    }

    public void goToPlayer()  //Este método se usará para cambiar la dirección hacia la posición del jugador
    {
        Debug.Log("Recibido");

        siguientePosicion = player.position;
        //velocidad = 5.0f;

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, siguientePosicion, velocidad * Time.deltaTime); /*el gameobject se mueve desde su posición hasta la siguiente
                                                                                                                     con una velocidad determinada*/

        if (Vector2.Distance(transform.position, siguientePosicion) < distanciaCambio)
        {
            numeroSigPosicion++; /*cuando la distancia entre el gameobject y la siguiente posición sea < 0.5f, 
                                 la siguiente posición cambia al siguiente elemento en el array de waypoints*/

            if (numeroSigPosicion == waypoints.Length) //si llega al final del array de waypoints, vuelve a la posición inicial
            {
                numeroSigPosicion = 0;
            }
            siguientePosicion = waypoints[numeroSigPosicion].position; //se establece la nueva posición

        }
    }
}
