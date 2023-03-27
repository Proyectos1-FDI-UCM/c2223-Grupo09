using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectaPlayer : MonoBehaviour
{
    //Este script se asigna a un área determinada en la que queramos detectar movimiento del jugador

    [field: SerializeField]
    public bool PlayerInArea { get; private set; } //booleano que indica si el jugador está en el área
    [SerializeField] GameObject Enemy;
    [SerializeField] bool Shoot;
    [SerializeField] bool Boss;

    public WayPointsMovement myWayPoints;  //referencia al componente de movimiento de los enemigos
    private ShootPlayer myShootPlayer;  //referencia al componente de movimiento de los enemigos
    private TutBossComponent _myBossComponent;

    [SerializeField]
    private string detectionTag = "Player";  //tag del player

    private void Start()
    {
        /*Para cambiar la dirección del enemigo al detectar al jugador en el área debemos establecer como nuevo punto de dirección la posición del jugador, 
        por ello necesitamos el componente WayPointsMovement*/
        if (Shoot)
        {
            myShootPlayer = Enemy.GetComponent<ShootPlayer>();
        }
        else if (Boss)
        {
            _myBossComponent = Enemy.GetComponent<TutBossComponent>();
        }
        else
        {
            myWayPoints = Enemy.GetComponent<WayPointsMovement>();   //el gameobject que queremos que actue
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(detectionTag))
        {
            //Si el tag de la colision es "Player", se reconoce que el jugador está en el área
            PlayerInArea = true;
            if (Shoot)
            {
                myShootPlayer.IsShooting = true;
            }
            else if (Boss)
            {
                _myBossComponent.Empiezo();
            }
            else
            {
                myWayPoints.goToPlayer(); //Se invoca al método que cambiará la dirección del enemigo a la del jugador
            }
        }
    }
   
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInArea = false;
            if (Shoot) myShootPlayer.IsShooting = false;
            else if (!Boss) myWayPoints.DontGoToPlayer();
        }
    }
}

