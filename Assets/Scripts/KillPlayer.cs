using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    #region references
    private PlayerLifeComponent _myPlayerLifeComponent; //referencia al Life Component del jugador
    private Collider2D _myBoxCollider;                  //Referencia al collider del enemigo
    private Rigidbody2D _myRigidbody;                   //Referencia al rigidbody del enemigo
    #endregion
    void Start()
    {
        _myBoxCollider = GetComponent<Collider2D>();
        _myRigidbody = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)  //Cuando un objeto colisiona con el enemigo
    {
        if (collision.gameObject.GetComponent<PlayerLifeComponent>() != null)   //se comprueba si este tiene un Script de Life Component
        {
            _myPlayerLifeComponent = collision.gameObject.GetComponent<PlayerLifeComponent>();      //se toma el Script PlayerLifeComponent
            _myPlayerLifeComponent.Hit();                                                           //se llama al metodo Hit de ese script
            StartCoroutine(I_Hit());                                                                //se llama al IEnumerator I_Hit
        }
    }
    IEnumerator I_Hit()     //este IEnumerator vuelve al enemigo atravesable por dos segundos (para evitar que el jugador choque con él mientras es invulnerable, lo que puede ser incómodo)
    {
        _myRigidbody.gravityScale = 0;
        _myBoxCollider.enabled = false;
        yield return new WaitForSeconds(2f);
        _myBoxCollider.enabled = true;
        _myRigidbody.gravityScale = 1;
    }
}
