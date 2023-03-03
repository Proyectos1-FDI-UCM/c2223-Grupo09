using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesSaws : MonoBehaviour
{
    #region references
    private PlayerLifeComponent _myPlayerLifeComponent; //referencia al Life Component del jugador
    private Collider2D _playerCollider;                 //Referencia al collider del player
    #endregion

    #region methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerLifeComponent>() != null) //si se ha colisionado con un objeto que contiene un PlayerLifeComponent
        {
            _playerCollider = collision;                                                             //se toma el collider del jugador
            _myPlayerLifeComponent = _playerCollider.gameObject.GetComponent<PlayerLifeComponent>(); //se toma el Script PlayerLifeComponent gracias al collider del jugador
            _myPlayerLifeComponent.SpikeDamage();                                                    //se llama al metodo SpikeDamage del PlayerLifeComponent
        }
    }
    #endregion
}
