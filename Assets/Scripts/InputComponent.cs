using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponent : MonoBehaviour
{
    #region References
    private MovementComponent _movementComponent;
    private AimComponent _aimComponent;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _movementComponent = GetComponent<MovementComponent>();
        _aimComponent = GetComponent<AimComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento lateral (izquierda) -> Parametro determina direccion
        if (Input.GetKey(KeyCode.A))        // GetKey se utiliza mientras esté pulsado
        {
            _movementComponent.Walk();
        }
        //Movimiento lateral (derecha) -> Parametro determina direccion
        if (Input.GetKey(KeyCode.D))
        {
            _movementComponent.Walk();
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
    }
}
