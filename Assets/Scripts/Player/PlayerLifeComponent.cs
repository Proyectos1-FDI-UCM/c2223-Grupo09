using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLifeComponent : MonoBehaviour
{
    #region references
    [SerializeField]
    private Vector2 _respawnSala3;                   //posicion donde hace respawn el jugador en el tutorial, primer checkpoint
    [SerializeField]
    private Vector2 _respawnSala4;                  //posicion donde hace respawn el jugador en el tutorial, segundo checkpoint
    private SpriteRenderer _mySpriteRenderer;   
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
    #endregion
    #region properties
    public bool invulnerable;      //variable que vuelve invulnerable al jugador a todo daño. Se usa cuando es golpeado, y se usará con los escudos es un futuro
    private bool _isDeath = false;
    private float _escudoCooldown = 5.0f;
    private bool _escudoAct = false;
    private bool _soundMade;
    private static PlayerLifeComponent _instance;
    public static PlayerLifeComponent Instance //acceso publico al instance
    {
        get
        {
            return _instance;
        }
    }
    private bool _checkPoint;
    #endregion
    #region Methods
    public void Hit()                           //metodo llamado desde el script KillPlayer de los enemigos
    {
        if (!invulnerable)                      //si no es invulnerable (por escudo o porque ya ha sido golpeado)
        {
            if(!_soundMade)AudioControler.Instance.PlaySound(_hitSound);
            GameManager.Instance.Hit();         //se resta una vida
            if (GameManager.Instance.Puntos_vida <= 0) GameOver(); //si llega a cero vidas, se activa el void de muerte
            else StartCoroutine(Invulnerable());       //si no ha llegado a cero vidas, se vuelve invulnerable  
        }
    }
    public void SpikeSawsDamage() //metodo llamado desde el script SpikeSaws (matan al jugador, es decir eliminan todas las vidas)
    {
        GameOver();
    }
    public void Comprar() //comprar escudo
    {
        if(_escudoAct == false) //si no está el escudo activado
        {
            GameManager.Instance.CompraEscudo();
        }
    }
    public void ActivaEscudo() //activar escudo
    {
        
        StartCoroutine(Escudo());
    }
    public void GameOver()                //carga la escena GameOver, metodo llamado cuando se pierden todas las vidas
    {
        if(!_soundMade) AudioControler.Instance.PlaySound(_gameOverSound);
        _soundMade = true;
        _myMovementComponent.enabled = false;
        _myInputComponent.enabled = false;
        _myRigidbody2D.velocity = new Vector2(0f, 0f);
        _isDeath = true;
        StartCoroutine(Wait());
    }
    private void Respawn() //respawn del jugador al morir
    {
        if (ControladorDeSalas.Instance.Sección == 0) //en el tutorial
        {
            if (_checkPoint == false) //si no ha alcanzado los checkpoints
            {
                SceneManager.LoadScene("Tutorial"); //empieza de nuevo
            }
            else
            {
                if (ControladorDeSalas.Instance.Sala == 3) //primer checkpoint del tutorial
                {
                    GameManager.Instance.GuardaEngranajes();
                    transform.position = _respawnSala3;
                    _myMovementComponent.enabled = true;
                    _myInputComponent.enabled = true;
                    _isDeath = false;
                }
                if (ControladorDeSalas.Instance.Sala == 4) //segundo checkpoint del tutorial
                {
                    GameManager.Instance.GuardaEngranajes();
                    transform.position = _respawnSala4;
                    _myMovementComponent.enabled = true;
                    _myInputComponent.enabled = true;
                    _isDeath = false;
                }
            }
        }
        //en el resto de secciones no hay checkpoints, carga la esecna de nuevo al morir
        else if (ControladorDeSalas.Instance.Sección == 1) SceneManager.LoadScene("Boss tutorial");
        else if (ControladorDeSalas.Instance.Sección == 2) SceneManager.LoadScene("NIVELES");
        else if (ControladorDeSalas.Instance.Sección == 3) SceneManager.LoadScene("INTERMEDIOS");
        else if (ControladorDeSalas.Instance.Sección == 4) SceneManager.LoadScene("DIFICILES");
        else if (ControladorDeSalas.Instance.Sección == 5)
        {
            _boss.Respawn(); //vuelve a respawnear el boss
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
        if(!_escudoAct)invulnerable = false;                               //después del tiempo de espera, se le quita la invulnerabilidad al jugador [ATENCIÓN: Cuando se haga el script del escudo protector                                                   //hay que vijilar que este IEnumerator no pueda desactivar la invencibilidad antes de que se acabe el tiempo del propio escudo]
    }
    IEnumerator Escudo()
    {
        _escudoAct = true; //el escudo se activa
        _myUIplayer.EscudoUI(); 
        invulnerable = true; //el jugador es invulnerable
        _escudo.SetActive(true); //se activa el sprite del escudo
        yield return new WaitForSeconds(_escudoCooldown); //se espera el cooldown
        invulnerable = false; //el jugador deja de ser invulnerable
        _escudo.SetActive(false); //se desactiva el sprite
        _escudoAct = false; //escudo desactivado
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        Respawn();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Checkpoint>() != null) //activar el checkpoint cuando se entra en contacto con él
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
        _soundMade = false;
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
