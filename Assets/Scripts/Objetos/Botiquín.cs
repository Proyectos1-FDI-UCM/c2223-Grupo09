using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botiquín : MonoBehaviour
{
    private PlayerLifeComponent _myPlayerLifeComponent;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerLifeComponent>() != null)                       //si el botiquín entra en contacto con el jugador
        {
            _myPlayerLifeComponent = collision.gameObject.GetComponent<PlayerLifeComponent>();      //se toma el Script PlayerLifeComponent de la colision (jugador)
            GameManager.Instance.Botiquin();
            Destroy(gameObject);                                                                    //Se destruye el botiquín
        }
    }
}
