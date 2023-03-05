using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponent : MonoBehaviour
{
    #region References
    private MovementComponent _movementComponent;
    private AimComponent _aimComponent;
    private ShootComponent _shootComponent;
    private SpriteRenderer _mySpriteRenderer;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _movementComponent = GetComponent<MovementComponent>();
        _aimComponent = GetComponent<AimComponent>();
        _shootComponent = GetComponent<ShootComponent>();
        _mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento lateral (izquierda) -> Parametro determina direccion
        if (Input.GetKey(KeyCode.A))        // GetKey se utiliza mientras esté pulsado
        {
            _movementComponent.Walk(-1);
            _mySpriteRenderer.flipX = true;
        }
        //Movimiento lateral (derecha) -> Parametro determina direccion
        if (Input.GetKey(KeyCode.D))
        {
            _movementComponent.Walk(1);
            _mySpriteRenderer.flipX = false;
        }
        //Salto
        if (Input.GetKeyDown(KeyCode.W))        // GetKeyDown se utiliza una vez al pulsarse la tecla
        {
            _movementComponent.Jump();
        }
        //Apuntar (derecha)
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //_aimComponent.Aim();
        }
        //Apuntar (izquierda)
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //_aimComponent.Aim();
        }
        //Apuntar (arriba)
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //_aimComponent.Aim();
        }
        //Disparar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _shootComponent.Shoot();
        }
        //Dash
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(_movementComponent.Dash());
        }
        //Correr izquierda
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.A))
        {
            _movementComponent.Run(-1);
        }
        //Correr derecha
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.D))
        {
            _movementComponent.Run(1);
        }
    }
}
