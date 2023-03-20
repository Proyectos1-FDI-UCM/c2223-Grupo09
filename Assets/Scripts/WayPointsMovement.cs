using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WayPointsMovement : MonoBehaviour
{
    //Este script sirve para cualquier gameobject que vaya a tener una ruta determinada, se puede usar tanto para los enemigos como para plataformas

    [SerializeField]
    private Transform[] waypoints; //puntos de cambio de dirección

    [SerializeField] private bool LockX;
    [SerializeField] private bool BossFinal;

    private Vector2 siguientePosicion; //posición siguiente a la que se debe llegar
    private int numeroSigPosicion = 0; //contador de posiciones

    [SerializeField]
    private float distanciaCambio = 1f; //distancia entre gameobject-waypoint en la que se debe cambiar de dirección

    [SerializeField]
    private Transform player;
    private bool FollowPlayer=false;

    [SerializeField]
    private float velocidadinicial; //velocidad del gameobject
    [SerializeField]
    private float velocidad;
    [SerializeField]
    private float velocidadAtaque;
    private float inputHorizontal;
    public bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        if (BossFinal)
        {
            waypoints[0] = GameObject.Find("Waypoint1").transform;
            waypoints[1] = GameObject.Find("Waypoint2").transform;
        }
        if (LockX)
        {
            siguientePosicion = new Vector2 (waypoints[0].position.x,transform.position.y); //se establece la primera posición a alcanzar sin contar la diferencia en Y
        }
        else
        {
            siguientePosicion = waypoints[0].position;  //se establece la primera posición a alcanzar
        }        

        velocidad = velocidadinicial;
    }

    public void goToPlayer()  //Este m?todo se usar? para cambiar la direcci?n hacia la posici?n del jugador
    {

        siguientePosicion = player.position; //la siguiente dirección será la posición del jugador
        FollowPlayer= true;
        velocidad = velocidadAtaque;   //se aumenta la velocidad
    }
    public void DontGoToPlayer()  //Este m?todo se usar? para cambiar la direcci?n hacia la posici?n del jugador
    {        
        FollowPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, siguientePosicion, velocidad * Time.deltaTime); /*el gameobject se mueve desde su posición hasta la siguiente
                                                                                                                     con una velocidad determinada*/

        if (Vector2.Distance(transform.position, siguientePosicion) < distanciaCambio)
        {
            velocidad = velocidadinicial;

            numeroSigPosicion++; /*cuando la distancia entre el gameobject y la siguiente posición sea < 0.5f, 
                                 la siguiente posición cambia al siguiente elemento en el array de waypoints*/

            if (numeroSigPosicion == waypoints.Length) //si llega al final del array de waypoints, vuelve a la posición inicial
            {
                numeroSigPosicion = 0;
            }
            if (LockX)
            {
                siguientePosicion = new Vector2(waypoints[numeroSigPosicion].position.x, transform.position.y); //se establece la nueva posición sin contar la diferencia en Y
            }
            else
            {
                siguientePosicion = waypoints[numeroSigPosicion].position; //se establece la nueva posición
            }
            
            FollowPlayer = false;

            if(gameObject.tag == "Enemy")
            {
                Flip();
            }

        }
        
        if (FollowPlayer)
        {
            siguientePosicion = player.position; //la siguiente dirección será la posición del jugador
        }


    }
    private void Flip()
    {
        Vector3 currentscale = gameObject.transform.localScale;

        currentscale.x *= -1;
        gameObject.transform.localScale = currentscale;

        facingRight = !facingRight;
    }
}


