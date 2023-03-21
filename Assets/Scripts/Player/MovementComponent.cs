using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    #region references
    private UIPlayer _myUIPlayer;
    #endregion
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
    private bool _coyoteTime;
    private bool _canJump=false;

    [Header("Animation")]
    private bool _isRunning = false;    //para saber si está corriendo
    private bool _isWalking = false;    //para saber si está caminando
    private bool _isDashing = false;    //para saber si está haciendo dash


    [Header("Movement")]
    [SerializeField]
    private float _myForce; //fuerza con la que se mueve el player
    [SerializeField]
    private float _myRunForce;
    float movementX = 0f; //para asignar la dirección donde vaya a ir el jugador
    bool lookingRight;

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
    [SerializeField]
    private AudioClip _dashSound;
    [SerializeField]
    private AudioClip _jumpSound;
    




    #endregion

    public float getDirection()
    {
        if (lookingRight) return 1;
        else if(!lookingRight) return -1;
        else return 0;
    }

    #region References
    private Rigidbody2D _myRigidBody2D; //referencia al rigidbody del player
    [SerializeField]
    private TrailRenderer _myTrailRenderer;
    private SpriteRenderer _mySpriteRenderer;
    private Animator _myAnimator;
    #endregion

    #region Methods
    void Start()
    {
        lookingRight = true;
        _myRigidBody2D= GetComponent<Rigidbody2D>();
        _onGround = true;
        _initialGravity = _myRigidBody2D.gravityScale;      //gravedad del jugador al inicio
        _mySpriteRenderer = GetComponent<SpriteRenderer>();
        _myAnimator = GetComponent<Animator>();
        _myUIPlayer = GetComponent<UIPlayer>();
    }

    private void FixedUpdate()
    {
        if (_canMove)           //solo si se puede mover puede realizarlo
        {            
            _coyoteTime = Physics2D.OverlapBox(_feet.position, _feetDimension, 0f, _ground);
            if (_coyoteTime != _onGround)
            {
                if (_coyoteTime) _onGround = true;
                else StartCoroutine(CoyoteTime());
            }
            if (!_coyoteTime)
            {
                _myRigidBody2D.AddForce(Vector2.down * _downforce);
            }
            //La nueva posicion del personaje dada por la x que se calcule con el GetAxis * la fuerza
            //que le queramos aplicar y sin modificar la posición Y
            _myRigidBody2D.velocity = new Vector2(movementX, _myRigidBody2D.velocity.y);
            movementX = 0f;
            Walk(0);
            Run(0);
            Jump();
            
        }
    }

    private void Update()
    {
        if (_myRigidBody2D.velocity.x == 0)     //si no se está moviendo se desactivan animaciones
        {
            _isWalking = false;
            _isRunning = false;
        }
        if (_myRigidBody2D.gravityScale == 0)
        {
            _isDashing = true;
        }
        else
        {
            _isDashing = false;
        }
        
        _myAnimator.SetBool("isRunning", _isRunning);
        _myAnimator.SetBool("isWalking", _isWalking);
        _myAnimator.SetBool("onGround", _onGround);
        _myAnimator.SetBool("isDashing", _isDashing);
    }
    public void Walk(float direction)
    {
       // direction = Input.GetAxisRaw("Horizontal"); //este valor puede ser -1, 0 o 1 indicando si va hacia la derecha, izquierda o no hay movimiento (funciona con joystick)
        movementX = direction* _myForce;
        if (direction == 1)
        {
            
            lookingRight = true;
            _isWalking = true;  //se aciva caminar
            _isRunning = false; //no está corriendo
        }
        else if (direction == -1)
        {
            
            lookingRight = false;
            _isWalking = true;  //se activa caminar
            _isRunning = false; //no está corriendo
        }  
    }
    public void Run(float direction)
    {
        movementX = direction * _myRunForce; //el jugador corre en el eje X con la fuerza establecida y en la direccion correspondiente
        if (direction == 1)
        {

            lookingRight = true;
            _isRunning = true;  //está corriendo
            _isWalking = false; //no anda
        }
        else if (direction == -1)
        {
            lookingRight = false;
            _isRunning = true;  //está corriendo
            _isWalking= false;  //no anda
        }
    }
    public void CanJump()
    {

        _canJump = true;
    }
    private void Jump()
    {
        if (_canJump && _onGround)
        {
            AudioControler.Instance.PlaySound(_jumpSound);
            _myRigidBody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _onGround = false;
            _coyoteTime = false;
            _canJump = false;

        }
    }
    public IEnumerator Dash()
    {
        if (_canDash)
        {
            _myUIPlayer.CanDashUI();
            _canJump = false;
            _canMove = false;   //se desabilita el movimiento
            _canDash = false;   //no se puede volver a hacer dash
            _myRigidBody2D.gravityScale = 0f;   // la gravedad se deja a 0
            //dependiendo de hacia donde mire el jugador, el dash se realiza hacia un lado u otro
            if (_mySpriteRenderer.flipX == true)
            {
                _myRigidBody2D.velocity = new Vector2(_dashVelocity * (-1f), 0f);
                AudioControler.Instance.PlaySound(_dashSound);
            }
            else
            {
                _myRigidBody2D.velocity = new Vector2(_dashVelocity * (1f), 0f);
                AudioControler.Instance.PlaySound(_dashSound);
            }
            _myTrailRenderer.emitting = true;                   //se activa la estela
            yield return new WaitForSeconds(_dashDuration);     //tiempo que dura el dash
            _myTrailRenderer.emitting = false;                  //se desactiva la estela
            _onGround = Physics2D.OverlapBox(_feet.position, _feetDimension, 0f, _ground);
            _canMove = true;                                    //se activa de nuevo el movimiento
            _myRigidBody2D.gravityScale = _initialGravity;      //se devuelve la gravedad inicial

            yield return new WaitForSeconds(_cooldown);         //tiempo de espera para volver a realizar el dash
            _canDash = true;                                    //se vuelve a activar el dash
        } 
    }
    //Funcion que muestra los "pies" del personaje
    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(_feet.position, _feetDimension);
    }
    IEnumerator CoyoteTime()
    {
        yield return new WaitForSeconds(0.04f);
        _onGround = false;
    }
    #endregion
}
