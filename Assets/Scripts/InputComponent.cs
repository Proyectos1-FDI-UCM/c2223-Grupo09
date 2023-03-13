using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponent : MonoBehaviour
{
    #region References
    private MovementComponent _movementComponent;
    private ShootComponent _shootComponent;
    private SpriteRenderer _mySpriteRenderer;
    private UIDash _myUIDash;
    #endregion

    #region Methods
    // Start is called before the first frame update
    void Start()
    {
        _movementComponent = GetComponent<MovementComponent>();
        _shootComponent = GetComponent<ShootComponent>();
        _mySpriteRenderer = GetComponent<SpriteRenderer>();
        _myUIDash = GetComponent<UIDash>();
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
            _movementComponent.CanJump();
        }
        //Disparar (derecha)
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _shootComponent.Shoot(Vector2.right);
        }
        //Disparar (izquierda)
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _shootComponent.Shoot(Vector2.left);
        }
        //Disparar (arriba)
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _shootComponent.Shoot(Vector2.up);
        }
        //Disparar (abajo)
        if (Input.GetKey(KeyCode.DownArrow))
        {
            _shootComponent.Shoot(Vector2.down);
        }
        //Disparar diagonal arriba izquierda
        if(Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            _shootComponent.Shoot(Vector2.up * Vector2.left);
        }
        //Disparar diagonal arriba derecha
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            _shootComponent.Shoot(Vector2.up * Vector2.right);
        }
        //Disparar diagonal abajo izquierda
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            _shootComponent.Shoot(Vector2.down * Vector2.left);
        }
        //Disparar diagonal abajo derecha
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            _shootComponent.Shoot(Vector2.up * Vector2.right);
        }
        //Dash
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(_movementComponent.Dash());
            _myUIDash.CanDashUI();
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
    #endregion
}
