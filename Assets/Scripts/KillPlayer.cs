using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    private PlayerLifeComponent _myPlayerLifeComponent;
    private Collider2D _myBoxCollider;
    private Rigidbody2D _myRigidbody;
    void Start()
    {
        _myBoxCollider = GetComponent<Collider2D>();
        _myRigidbody = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerLifeComponent>() != null)//si el enemigo entra en contacto con el jugador
        {
            _myPlayerLifeComponent = collision.gameObject.GetComponent<PlayerLifeComponent>();// se toma el Script PlayerLifeComponent de la colision (jugador)
            _myPlayerLifeComponent.Hit();//se llama al metodo Die de ese script
            StartCoroutine(I_Hit());
        }
    }
    IEnumerator I_Hit()
    {
        _myRigidbody.gravityScale = 0;
        _myBoxCollider.enabled = false;
        yield return new WaitForSeconds(2f);
        _myBoxCollider.enabled = true;
        _myRigidbody.gravityScale = 1;
    }
}
