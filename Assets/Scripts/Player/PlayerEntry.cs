using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerEntry : MonoBehaviour
{
    #region properties
    private InputComponent _myInputComponent;
    private MovementComponent _myMovementComponent;
    private SpriteRenderer _mySpriteRenderer;
    private bool dentro;
    private bool fin;
    private bool activar;
    [SerializeField]
    private GameObject _entrada;
    #endregion
    #region Methods
    private void OnTriggerEnter2D(Collider2D collision) //cuando el jugador entra al trigger de entrada
    {
        if (collision.gameObject.GetComponent<PlayerLifeComponent>() != null)
        {
            dentro= true;
            _myInputComponent = collision.GetComponent<InputComponent>();
            _myMovementComponent = collision.GetComponent<MovementComponent>();
            _mySpriteRenderer = collision.GetComponent<SpriteRenderer>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision) //cuando el jugador sale del trigger de entrada
    {
        if (collision.gameObject.GetComponent<PlayerLifeComponent>() != null)
        {
            _myInputComponent.enabled = true; //se activa el input
            dentro = false;
            fin = true;
            activar = true; //se activa el collider entrada
        }
    }
    private void Entrada() //animacion de entrada a una sala
    {
        _myInputComponent.enabled = false; //se deshabilita el input
        _myMovementComponent.Walk(1); //el jugador anda para hacer la animacion de entrada
        _mySpriteRenderer.flipX = false;
    }
    #endregion
    void Start()
    {
        dentro = false;
        fin = false;
        activar = false;
        _entrada.SetActive(false); //collider de entrada al principio desactivado
    }
    void Update()
    {
        if (dentro) Entrada(); //si el jugador esta en el trigger de entrada, se hace la animacion de entrar
        if(fin) this.enabled = false;
        if (activar) _entrada.SetActive(true); //el collider de entrada se activa (sirve para que el jugador no vaya hacia atras ni salga de la seccion)
    }
}
