using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    #region Parameters
    [SerializeField]
    private float _myForce; //fuerza con la que se mueve el player
    #endregion

    #region References
    private Rigidbody _myRigidBody2D; //referencia al rigidbody del player
    #endregion



    // Start is called before the first frame update
    void Start()
    {
        _myRigidBody2D= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float movementX = Input.GetAxisRaw("Horizontal");  //este valor puede ser -1, 0 o 1 indicando si va hacia la derecha, izquierda o no hay movimiento (funciona con joystick)
        Vector2 playerPosition = transform.position;
         
        playerPosition = playerPosition + new Vector2 (movementX, 0f) * _myForce * Time.deltaTime;
        transform.position = playerPosition;
    }
}
