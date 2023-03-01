using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    float movementX = 0f; //para asignar la direcci�n donde vaya a ir el jugador
    float direction;

    [Header("Dash")]
    [SerializeField]
    private float _dashVelocity;
    [SerializeField]
    private float _dashDuration;
    private float _initialGravity;
    [SerializeField]
    private float _cooldown = 2f;
    private bool _canDash = true;
    private bool _canMove = true;
    #endregion

    #region References
    private Rigidbody2D _myRigidBody2D; //referencia al rigidbody del player
    [SerializeField]
    private TrailRenderer _myTrailRenderer;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _myRigidBody2D= GetComponent<Rigidbody2D>();
        _onGround = true;
        _initialGravity = _myRigidBody2D.gravityScale;      //gravedad del jugador al inicio
    }

    private void FixedUpdate()
    {
        if (_canMove)           //solo si se puede mover puede realizarlo
        {
            _onGround = Physics2D.OverlapBox(_feet.position, _feetDimension, 0f, _ground);
            if (!_onGround)
            {
                _myRigidBody2D.AddForce(Vector2.down * _downforce);
            }
            //La nueva posicion del personaje dada por la x que se calcule con el GetAxis * la fuerza
            //que le queramos aplicar y sin modificar la posici�n Y
            _myRigidBody2D.velocity = new Vector2(movementX, _myRigidBody2D.velocity.y);

            movementX = 0f;
        }
        
    }
    public void Walk(float direction)
    {
       // direction = Input.GetAxisRaw("Horizontal"); //este valor puede ser -1, 0 o 1 indicando si va hacia la derecha, izquierda o no hay movimiento (funciona con joystick)
        movementX = direction* _myForce;
    }
    public void Jump()
    {
        if (_onGround)
        {
            _myRigidBody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _onGround = false;
        }
    }

    public IEnumerator Dash()
    {
        if (_canDash)
        {
            _canMove = false;   //se desabilita el movimiento
            _canDash = false;   //no se puede volver a hacer dash
            _myRigidBody2D.gravityScale = 0f;   // la gravedad se deja a 0
            _myRigidBody2D.velocity = new Vector2(_dashVelocity * transform.localScale.x, 0);   //se mueve al player con la velocidad y en la direcci�n donde est� mirando
            _myTrailRenderer.emitting = true;       //se activa la estela
            yield return new WaitForSeconds(_dashDuration);     //tiempo que dura el dash
            _canMove = true;    //se activa de nuevo el movimiento
            _myRigidBody2D.gravityScale = _initialGravity;      //se devuelve la gravedad inicial
            _myTrailRenderer.emitting = false;      //se desactiva la estela
            yield return new WaitForSeconds(_cooldown);     //tiempo de espera para volver a realizar el dash
            _canDash = true;     //se vuelve a activar el dash
        }
       
    }

    //Funcion que muestra los "pies" del personaje
    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(_feet.position, _feetDimension);
    }
}
