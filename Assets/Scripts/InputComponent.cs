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
        if (Input.GetKeyDown(KeyCode.A))
        {
            _movementComponent.Walk();
        }
        //Movimiento lateral (derecha) -> Parametro determina direccion
        if (Input.GetKeyDown(KeyCode.D))
        {
            _movementComponent.Walk();
        }
        //Salto
        if (Input.GetKeyDown(KeyCode.W))
        {
            _movementComponent.Jump();
        }
        //Apuntar (derecha)
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //_aimComponent.Aim();
        }
        //Apuntar (izquierda)
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //_aimComponent.Aim();
        }
        //Apuntar (arriba)
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //_aimComponent.Aim();
        }
    }
}
