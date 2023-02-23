using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    #region references
    private PlayerLifeComponent _myPlayerLifeComponent; //referencia al Life Component del jugador
    private Collider2D _playerCollider;                 //Referencia al collider del player
    private Collider2D _myBoxCollider;                  //Referencia al collider del enemigo
    #endregion
    void Start()
    {
        _myBoxCollider = GetComponent<Collider2D>();
    }
    IEnumerator Sigue_ahí()     //este IEnumerator sirve para que, si el jugador no sale del trigger del enemigo, este aun así le haga daño cuando acabe su inmortalidad
    {        
        yield return new WaitForSeconds(2.6f);
        if (_myBoxCollider.IsTouching(_playerCollider))
        {
            _myPlayerLifeComponent.Hit();
            StartCoroutine(Sigue_ahí());
        }            
    }
    private void OnTriggerEnter2D(Collider2D collision) //Cuando el enemigo colisiona con el enemigo
    {
        if (collision.gameObject.GetComponent<PlayerLifeComponent>() != null)   //se comprueba si este tiene un Script de Life Component
        {
            _playerCollider = collision;                                                                //se toma el collider del jugador
            _myPlayerLifeComponent = _playerCollider.gameObject.GetComponent<PlayerLifeComponent>();    //se toma el Script PlayerLifeComponent                                                            
            _myPlayerLifeComponent.Hit();                                                               //se llama al metodo Hit de ese script
            StartCoroutine(Sigue_ahí());
        }
    }
}
