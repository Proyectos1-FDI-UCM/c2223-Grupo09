using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    #region Parameters
    [SerializeField]
    private float _myForce; //fuerza con la que se mueve el player
    float movementX = 0f; //para asignar la dirección donde vaya a ir el jugador
    #endregion

    #region References
    private Rigidbody2D _myRigidBody2D; //referencia al rigidbody del player
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _myRigidBody2D= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void Update()
    {
        Walk();      //se llama al metodo en cada frame porque si no el personaje resbala

    }

    public void Walk()
    {
        movementX = Input.GetAxisRaw("Horizontal"); //este valor puede ser -1, 0 o 1 indicando si va hacia la derecha, izquierda o no hay movimiento (funciona con joystick)
        _myRigidBody2D.velocity = new Vector2(movementX * _myForce, _myRigidBody2D.velocity.y);  //la nueva posicion del personaje dada por la x que se calcule con el GetAxis * la fuerza que le queramos aplicar y sin modificar la posición y
    }
    public void Jump()
    {
        
    }
}
