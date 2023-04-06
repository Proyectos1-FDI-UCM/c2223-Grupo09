using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLifeComponent : MonoBehaviour
{
    #region properties
    private static PlayerLifeComponent _instance;
    public static PlayerLifeComponent Instance
    {
        get
        {
            return _instance;
        }
    }
    private bool _checkPoint;
    public bool CheckPoint
    {
        get
        {
            return _checkPoint;
        }
    }
    #endregion
    #region references
    [SerializeField]
    private Vector2 _respawnSala3;                   //posicion donde hace respawn el jugador (Debería ajustarse según el nivel)
    [SerializeField]
    private Vector2 _respawnSala4;
    private SpriteRenderer _mySpriteRenderer;   //referencia al sprite Reneder
    private Animator _myAnimator;
    private Rigidbody2D _myRigidbody2D;
    private MovementComponent _myMovementComponent;
    private BossComponent _boss;
    private InputComponent _myInputComponent;
    [SerializeField]
    private AudioClip _gameOverSound;
    [SerializeField]
    private AudioClip _hitSound;
    [SerializeField]
    private GameObject _escudo;
    private UIPlayer _myUIplayer;
    private int _gear;
    #endregion
    #region properties
    public bool invulnerable;      //variable que vuelve invulnerable al jugador a todo daño. Se usa cuando es golpeado, y se usará con los escudos es un futuro
    private bool _isDeath = false;
    private bool _isHit = false;
    private float _escudoCooldown = 10.0f;
    private bool _escudoAct = false;
    
    #endregion
    #region Methods
    public void Hit()                           //metodo llamado desde el script KillPlayer de los enemigos
    {
        if (!invulnerable)                      //si no es invulnerable (por escudo o porque ya ha sido golpeado)
        {
            AudioControler.Instance.PlaySound(_hitSound);
            GameManager.Instance.Hit();         //se resta una vida
            if (GameManager.Instance.Puntos_vida <= 0) GameOver(); //si llega a cero vidas, se activa el void de muerte
            else StartCoroutine(Invulnerable());       //si no ha llegado a cero vidas, se vuelve invulnerable  
        }
    }
    public void SpikeSawsDamage() //metodo llamado desde el script SpikeSaws (matan al jugador, es decir eliminan todas las vidas)
    {
        GameOver();
    }
    public void Comprar()
    {
        if(_escudoAct == false)
        {
            GameManager.Instance.CompraEscudo();
        }
    }
    public void ActivaEscudo()
    {
        
        StartCoroutine(Escudo());
    }
    public void GameOver()                //carga la escena GameOver, metodo llamado cuando se pierden todas las vidas
    {
        AudioControler.Instance.PlaySound(_gameOverSound);
        _myMovementComponent.enabled = false;
        _myInputComponent.enabled = false;
        _myRigidbody2D.velocity = new Vector2(0f, 0f);
        _isDeath = true;
        StartCoroutine(Wait());
    }
    private void Respawn()
    {
        if (ControladorDeSalas.Instance.Sección == 0)
        {
            if (_checkPoint == false)
            {
                SceneManager.LoadScene("Tutorial");
            }
            else
            {
                if (ControladorDeSalas.Instance.Sala == 3)
                {
                    GameManager.Instance.GuardaEngranajes();
                    transform.position = _respawnSala3;
                    _myMovementComponent.enabled = true;
                    _myInputComponent.enabled = true;
                    _isDeath = false;
                }
                if (ControladorDeSalas.Instance.Sala == 4)
                {
                    GameManager.Instance.GuardaEngranajes();
                    transform.position = _respawnSala4;
                    _myMovementComponent.enabled = true;
                    _myInputComponent.enabled = true;
                    _isDeath = false;
                }

            }
        }
        else if (ControladorDeSalas.Instance.Sección == 1) SceneManager.LoadScene("Boss tutorial");
        else if (ControladorDeSalas.Instance.Sección == 2) SceneManager.LoadScene("NIVELES");
        else if (ControladorDeSalas.Instance.Sección == 3) SceneManager.LoadScene("INTERMEDIOS");
        else if (ControladorDeSalas.Instance.Sección == 4) SceneManager.LoadScene("DIFICILES");
        else if (ControladorDeSalas.Instance.Sección == 5)
        {
            _boss.Respawn();
            SceneManager.LoadScene("Boss final");
        }            
        GameManager.Instance.Respawn();

    }
    IEnumerator Invulnerable()
    {
        invulnerable = true;                                //se vuelve invulnerable al jugador
        
        for (int i = 0; i < 5; i++)                          //este bucle for está aquí para hacer un efecto de parpadeo del jugador
        {
            _mySpriteRenderer.enabled = false;              //se vuelve invisible el jugador
            yield return new WaitForSeconds(0.1f);
            _mySpriteRenderer.color = new Color(1f, 0f, 0f, 1f);
            _mySpriteRenderer.enabled = true;               //se vuelve visible el jugador
            yield return new WaitForSeconds(0.2f);
            _mySpriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(0.2f);
        }
        invulnerable = false;                               //después del tiempo de espera, se le quita la invulnerabilidad al jugador [ATENCIÓN: Cuando se haga el script del escudo protector                                                   //hay que vijilar que este IEnumerator no pueda desactivar la invencibilidad antes de que se acabe el tiempo del propio escudo]
    }
    IEnumerator Escudo()
    {
        _escudoAct = true;
        _myUIplayer.EscudoUI();
        invulnerable = true;
        _escudo.SetActive(true);
        yield return new WaitForSeconds(_escudoCooldown);
        invulnerable = false;
        _escudo.SetActive(false);
        _escudoAct = false;
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        Respawn();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Checkpoint>() != null)
        {
            _checkPoint = true;
            GameManager.Instance.GuardaDatos();
        }
    }
        #endregion
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        _mySpriteRenderer = GetComponent<SpriteRenderer>();
        _myAnimator = GetComponent<Animator>();
        _myMovementComponent = GetComponent<MovementComponent>();
        _myInputComponent = GetComponent<InputComponent>();
        _myRigidbody2D = GetComponent<Rigidbody2D>();
        invulnerable = false;
        _myUIplayer = GetComponent<UIPlayer>();
        _mySpriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        _checkPoint = false;
    }

    private void Start()       
    {
        _escudo.SetActive(false);
        if (ControladorDeSalas.Instance.Sección == 5)
        {
            _boss = GameObject.Find("Final Boss").GetComponent<BossComponent>();
        }
    }
    private void Update()
    {
        _myAnimator.SetBool("isDeath", _isDeath);
    }
}
