using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectaPlayer : MonoBehaviour
{
    //Este script se asigna a un área determinada en la que queramos detectar movimiento del jugador

    [field: SerializeField]
    public bool PlayerInArea { get; private set; } //booleano que indica si el jugador está en el área
    [SerializeField] GameObject Enemy;

    private WayPointsMovement myWayPoints;  //referencia al componente de movimiento de los enemigos

    [SerializeField]
    private string detectionTag = "Player";  //tag del player

    private void Start()
    {
        /*Para cambiar la dirección del enemigo al detectar al jugador en el área debemos establecer como nuevo punto de dirección la posición del jugador, 
        por ello necesitamos el componente WayPointsMovement*/

        myWayPoints = GetComponent<WayPointsMovement>();
        myWayPoints = Enemy.GetComponent<WayPointsMovement>();   //el gameobject que queremos que actue
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(detectionTag))
        {
            //Si el tag de la colision es "Player", se reconoce que el jugador está en el área
            PlayerInArea = true; 
            
            myWayPoints.goToPlayer(); //Se invoca al método que cambiará la dirección del enemigo a la del jugador
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInArea = false;
        }
    }
}
