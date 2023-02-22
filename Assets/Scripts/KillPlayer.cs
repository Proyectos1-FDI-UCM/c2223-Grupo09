using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    private PlayerLifeComponent _myPlayerLifeComponent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))//si el enemigo entra en contacto con el jugador
        {
           _myPlayerLifeComponent = collision.GetComponent<PlayerLifeComponent>();// se toma el Script PlayerLifeComponent de la colision (jugador)
           _myPlayerLifeComponent.Die();//se llama al metodo Die de ese script
        }
    }
}
