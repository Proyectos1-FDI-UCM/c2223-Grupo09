using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectaPlayer : MonoBehaviour
{
    //Este script se asigna a un �rea determinada en la que queramos detectar movimiento del jugador

    [field: SerializeField]
    public bool PlayerInArea { get; private set; }  //booleano que indica si el jugador est� en el �rea
    //public Transform Player { get; private set; }   //transform del player
    
    private WayPointsMovement myWayPoints;          //referencia al componente de movimiento de los enemigos

    [SerializeField]
    private string detectionTag = "Player";         //tag del player

    private void Start()
    {
        /*Para cambiar la direcci�n del enemigo al detectar al jugador en el �rea debemos establecer como nuevo punto de direcci�n la posici�n del jugador, 
        por ello necesitamos el componente WayPointsMovement*/

        myWayPoints = GetComponent<WayPointsMovement>();
        myWayPoints = GameObject.FindGameObjectWithTag("Enemy").GetComponent<WayPointsMovement>();    //el gameobject que queremos que actue
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(detectionTag))
        {
            //Si el tag de la colision es "Player", se reconoce que el jugador est� en el �rea
            Debug.Log("player detected");
            PlayerInArea = true; 
            
            myWayPoints.goToPlayer(); //Se invoca al m�todo que cambiar� la direcci�n del enemigo a la del jugador

            //Player = collision.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInArea = false;
            //Player = null;
        }
    }

}
