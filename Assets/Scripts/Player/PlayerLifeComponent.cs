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
    #endregion
    #region properties
    public bool invulnerable;      //variable que vuelve invulnerable al jugador a todo daño. Se usa cuando es golpeado, y se usará con los escudos es un futuro
    private int puntos_vida_max;   //controla el número máximo de vidas que puede tener el jugador
    private int puntos_vida;       //cuenta el número de vidas del jugador
    private bool _isDeath = false;
    private bool _isHit = false;
    #endregion
    #region Methods
    public void Hit()                           //metodo llamado desde el script KillPlayer de los enemigos
    {
        if (!invulnerable)                      //si no es invulnerable (por escudo o porque ya ha sido golpeado)
        {
            GameManager.Instance.Hit();         //se resta una vida
            if (GameManager.Instance.Puntos_vida <= 0) GameOver();//Die();  //si llega a cero vidas, se activa el void de muerte
            else StartCoroutine(Invulnerable());       //si no ha llegado a cero vidas, se vuelve invulnerable  
        }
    }
    public void SpikeSawsDamage() //metodo llamado desde el script SpikeSaws (matan al jugador, es decir eliminan todas las vidas)
    {
        //Die();
        GameOver();
    }
    public void GameOver()                //carga la escena GameOver, metodo llamado cuando se pierden todas las vidas
    {
        AudioControler.Instance.PlaySound(_gameOverSound);
        _myMovementComponent.enabled = false;
        _myInputComponent.enabled = false;
        _myRigidbody2D.velocity = new Vector2(0f, 0f);
        _isDeath = true;

       // string sceneName = "GameOver";
        //SceneManager.LoadScene(sceneName);
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
    #endregion
    void Awake()
    {
        _mySpriteRenderer = GetComponent<SpriteRenderer>();
        _myAnimator = GetComponent<Animator>();
        _myMovementComponent = GetComponent<MovementComponent>();
        _myInputComponent = GetComponent<InputComponent>();
        _myRigidbody2D = GetComponent<Rigidbody2D>();
        invulnerable = false;
    }

    private void Start()
    {
        puntos_vida = GameManager.Instance.Puntos_vida;
        puntos_vida_max = GameManager.Instance.Puntos_vida_max;
    }
    private void Update()
    {
        _myAnimator.SetBool("isDeath", _isDeath);
    }
}
