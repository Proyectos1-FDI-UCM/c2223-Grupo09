using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletEnemy : MonoBehaviour
{
    #region references
    private PlayerLifeComponent _myPlayerLifeComponent; //referencia al Life Component del jugador
    private Collider2D _playerCollider;                 //Referencia al collider del player
    #endregion
    #region Parameters
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _damage;
    private GameObject _player;
    private bool _dir = false;
    private bool facingRight = false;
    #endregion

    #region Methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerLifeComponent>() != null)
        {
            _playerCollider = collision;                                                                //se toma el collider del jugador
            _myPlayerLifeComponent = _playerCollider.gameObject.GetComponent<PlayerLifeComponent>();    //se toma el Script PlayerLifeComponent                                                            
            _myPlayerLifeComponent.Hit();                                                               //se llama al metodo Hit de ese script
        }
    }
    public float Damage()
    { return _damage; }


    public void BalaRight()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }

    public void BalaLeft()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }
    #endregion

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        if (transform.position.x > _player.transform.position.x)
        {
            _dir = false;
        }

        else if (transform.position.x < _player.transform.position.x)
        {
            _dir = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(_dir)
        {
            Flip();
            BalaRight();
        }

        else
        {
            BalaLeft();
        }

        /*if(transform.position.x < -11.0f || transform.position.x > 10.0f)
        {
            Destroy(gameObject);
        }*/
        
    }
    private void Flip()
    {
        Vector3 currentscale = gameObject.transform.localScale;

        currentscale.x *= -1;
        gameObject.transform.localScale = currentscale;

        facingRight = !facingRight;
    }
}

