using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    #region Parameters
    [Header("Jump")]
    [SerializeField]
    private float _jumpForce; //Fuerza de salto
    [HideInInspector]
    public bool _onGround; //Comprueba si esta en el suelo
    [SerializeField]
    private float _downforce; //Se activa al dejar de presionar
    [SerializeField]
    private LayerMask _ground; //Determina que superficies son suelo
    [SerializeField]
    private Transform _feet;
    [SerializeField]
    private Vector3 _feetDimension;
    [Header("Movement")]
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
        _onGround = true;
    }

    // Update is called once per frame
    public void Update()
    {
        //  Walk();      //se llama al metodo en cada frame porque si no el personaje resbala
    }

    private void FixedUpdate()
    {
        _onGround = Physics2D.OverlapBox(_feet.position, _feetDimension, 0f, _ground);
        if (!_onGround)
        {
            _myRigidBody2D.AddForce(Vector2.down * _downforce);
        }
    }

    public void Walk()
    {
        movementX = Input.GetAxisRaw("Horizontal"); //este valor puede ser -1, 0 o 1 indicando si va hacia la derecha, izquierda o no hay movimiento (funciona con joystick)
        _myRigidBody2D.velocity = new Vector2(movementX * _myForce, _myRigidBody2D.velocity.y);  //la nueva posicion del personaje dada por la x que se calcule con el GetAxis * la fuerza que le queramos aplicar y sin modificar la posición y
    }
    public void Jump()
    {
        if (_onGround)
        {
            _myRigidBody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _onGround = false;
        }
    }

    //Funcion que muestra los "pies" del personaje
    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(_feet.position, _feetDimension);
    }
}
