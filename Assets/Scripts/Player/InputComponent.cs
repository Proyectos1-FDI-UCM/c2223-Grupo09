using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputComponent : MonoBehaviour
{
    #region Atributes
    [SerializeField]
    private float _coolDownShoot = 0.2f;
    [SerializeField]
    private float _lastTimeShot;
    #endregion

    #region References
    private MovementComponent _movementComponent;
    private ShootComponent _shootComponent;
    private SpriteRenderer _mySpriteRenderer;
    //private PlayerLifeComponent _playerLifeComponent;
    #endregion

    #region Methods
    // Start is called before the first frame update
    void Start()
    {
        _coolDownShoot = 0.15f;
        _movementComponent = GetComponent<MovementComponent>();
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
            _movementComponent.CanJump();
        }

        //Disparar diagonal arriba izquierda
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow)
            && _lastTimeShot >= _coolDownShoot)
        {
            FlipBeforeAttack(Vector2.left);
            _shootComponent.Shoot(Vector2.up + Vector2.left);
            _lastTimeShot = 0;
            _mySpriteRenderer.flipX = true;
        }
        //Disparar diagonal arriba derecha
        else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow)
            && _lastTimeShot >= _coolDownShoot)
        {
            FlipBeforeAttack(Vector2.right);
            _shootComponent.Shoot(Vector2.up + Vector2.right);
            _lastTimeShot = 0;
        }
        //Disparar (arriba)
        else if (Input.GetKey(KeyCode.UpArrow)
            && _lastTimeShot >= _coolDownShoot)
        {
            _shootComponent.Shoot(Vector2.up);
            _lastTimeShot = 0;
        }
        //Disparar (derecha)
        else if (Input.GetKey(KeyCode.RightArrow)
            && _lastTimeShot >= _coolDownShoot)
        {
            FlipBeforeAttack(Vector2.right);
            _shootComponent.Shoot(Vector2.right);
            _lastTimeShot = 0;
        }
        //Disparar (izquierda)
        else if (Input.GetKey(KeyCode.LeftArrow)
            && _lastTimeShot >= _coolDownShoot)
        {
            FlipBeforeAttack(Vector2.left);
            _shootComponent.Shoot(Vector2.left);
            _lastTimeShot = 0;
        }
        else
        {
            _lastTimeShot += Time.deltaTime;
        }

        //Dash
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(_movementComponent.Dash());
        }
        //Correr izquierda
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.A))
        {
            _movementComponent.Run(-1);
        }
        //Correr derecha
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.D))
        {
            _movementComponent.Run(1);
        }
        //Comprar vidas con engranajes
        if (Input.GetKeyDown(KeyCode.V))
        {
            GameManager.Instance.CompraVida();
        }
        //Comprar escudos con engranajes
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerLifeComponent.Instance.Comprar();
        }
        //Salir al menu principal dentro de los niveles
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.Escape();
            SceneManager.LoadScene("MenuPrincipal");
        }
    }

    private void FlipBeforeAttack(Vector2 dir)
    {
        if(dir == Vector2.right && _mySpriteRenderer.flipX)
        {
            _mySpriteRenderer.flipX = false;
        }
        if(dir == Vector2.left && !_mySpriteRenderer.flipX)
        {
            _mySpriteRenderer.flipX = true;
        }
    }
    #endregion
}
