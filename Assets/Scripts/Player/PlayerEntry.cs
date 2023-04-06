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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerLifeComponent>() != null)
        {
            dentro= true;
            _myInputComponent = collision.GetComponent<InputComponent>();
            _myMovementComponent = collision.GetComponent<MovementComponent>();
            _mySpriteRenderer = collision.GetComponent<SpriteRenderer>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerLifeComponent>() != null)
        {
            _myInputComponent.enabled = true;
            dentro = false;
            fin = true;
            activar = true;
        }
    }
    private void Entrada()
    {
        _myInputComponent.enabled = false;
        _myMovementComponent.Walk(1);
        _mySpriteRenderer.flipX = false;
    }
    #endregion
    void Start()
    {
        dentro = false;
        fin = false;
        activar = false;
        _entrada.SetActive(false);
    }
    void Update()
    {
        if (dentro) Entrada();
        if(fin) this.enabled = false;
        if (activar) _entrada.SetActive(true);
    }
}
