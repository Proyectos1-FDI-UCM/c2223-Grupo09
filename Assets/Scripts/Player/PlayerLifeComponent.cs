using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLifeComponent : MonoBehaviour
{
    #region references
    [SerializeField]
    private Vector2 _respawn;                   //posicion donde hace respawn el jugador (Debería ajustarse según el nivel)
    private SpriteRenderer _mySpriteRenderer;   //referencia al sprite Reneder
    private Animator _myAnimator;
    private Rigidbody2D _myRigidbody2D;
    private MovementComponent _myMovementComponent;
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
    private bool _isHit = false;
    private float _escudoCooldown = 10.0f;
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
    public void ActivaEscudo()
    {
        StartCoroutine(InvulnerableEscudo());
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
        //if(seccion=0)
        //string sceneName = "GameOver";
        SceneManager.LoadScene("Tutorial");
        GameManager.Instance.Respawn();
    }
    IEnumerator Invulnerable()
    {
        invulnerable = true;                                //se vuelve invulnerable al jugador
        for (int i = 0; i < 5; i++)                          //este bucle for está aquí para hacer un efecto de parpadeo del jugador
        {
            _mySpriteRenderer.enabled = false;              //se vuelve invisible el jugador
            yield return new WaitForSeconds(0.1f);
            _mySpriteRenderer.enabled = true;               //se vuelve visible el jugador
            yield return new WaitForSeconds(0.4f);
        }
        invulnerable = false;                               //después del tiempo de espera, se le quita la invulnerabilidad al jugador [ATENCIÓN: Cuando se haga el script del escudo protector                                                   //hay que vijilar que este IEnumerator no pueda desactivar la invencibilidad antes de que se acabe el tiempo del propio escudo]
    }
    IEnumerator InvulnerableEscudo()
    {
        _myUIplayer.EscudoUI();
        invulnerable = true;
        _escudo.SetActive(true);
        yield return new WaitForSeconds(_escudoCooldown);
        invulnerable = false;
        _escudo.SetActive(false);
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        Respawn();
    }
    #endregion
    void Awake()
    {
        _mySpriteRenderer = GetComponent<SpriteRenderer>();
        _myAnimator = GetComponent<Animator>();
        _myMovementComponent = GetComponent<MovementComponent>();
        _myInputComponent = GetComponent<InputComponent>();
        _myRigidbody2D = GetComponent<Rigidbody2D>();
        invulnerable = false;
        _escudo.SetActive(false);
        _myUIplayer = GetComponent<UIPlayer>();
    }

    private void Start()
    {
    }
    private void Update()
    {
        _myAnimator.SetBool("isDeath", _isDeath);
    }
}
