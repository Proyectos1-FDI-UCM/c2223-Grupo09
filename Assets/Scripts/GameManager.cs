using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region references
    /*[SerializeField]
     private GameObject _player;

     private PlayerLifeComponent _myLifeComponent;*/
    [SerializeField] private AudioClip _compraVida;
    [SerializeField] private AudioClip _compraEscudo;
    #endregion
    #region properties
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private int _gear; //numero de engranajes
    public int Gear    //acceso publico al numero de engranajes
    {
        get
        {
            return _gear;
        }
    }

    private int puntos_vida; //cuenta el número de vidas del jugador
    public int Puntos_vida   //acceso público a los puntos de vida actuales del jugador
    {
        get { return puntos_vida; }
    }

    private int puntos_vida_max; //controla el número máximo de vidas que puede tener el jugador. Empieza con 3, pero puede aumentar comprando más vidas con los engranajes
    public int Puntos_vida_max   //acceso público a los de de vida maximos del jugador
    {
        get { return puntos_vida_max; }
    }
    private int lastGear;
    private int lastPuntos_vida;
    private int lastPuntos_vida_max;
    #endregion
    #region Methods
    public void OnPickGear()
    {
        _gear++;
    }
    public void Hit()
    {
        puntos_vida--;
    }
    public void Botiquin()
    {
        puntos_vida = puntos_vida_max; //se curan todas las vidas del jugador
    }
    public void SpikeSawsDamage() //metodo llamado desde el script SpikeSaws (matan al jugador, es decir eliminan todas las vidas)
    {
        puntos_vida = 0;
    }
    public void CompraEscudo()
    {
        if (_gear >= 5)
        {
            AudioControler.Instance.PlaySound(_compraEscudo);
            PlayerLifeComponent.Instance.ActivaEscudo();
            _gear = _gear - 5;
        }
    }
    public void CompraVida()
    {
        if (puntos_vida_max < 6)
        {
            if (_gear >= 10)
            {
                AudioControler.Instance.PlaySound(_compraVida);
                puntos_vida++;
                puntos_vida_max++;
                _gear = _gear - 10;
            }
        }
    }
    public void GuardaDatos()
    {
        lastGear = _gear;
        lastPuntos_vida = puntos_vida;
        lastPuntos_vida_max = puntos_vida_max;
    }
    public void Respawn()
    {
        if (ControladorDeSalas.Instance.Sección == 1 && ControladorDeSalas.Instance.Sala < 3)
        {
            _gear = 0;
            puntos_vida = 3;
            puntos_vida_max = 3;
        }
        else
        {
            puntos_vida = lastPuntos_vida;
            puntos_vida_max = lastPuntos_vida_max;
            _gear = lastGear;
        }
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion
    void Start()
    {
        _gear = 0;
        puntos_vida = 3;     //siempre se empieza con tres vidas, se van perdiendo segun el daño recibido
        puntos_vida_max = 3; //siempre se empieza con tres vidas como maximo, estas pueden aumentar cuando se compren con los engranajes
                             //  _myLifeComponent = _player.GetComponent<PlayerLifeComponent>();
    }
    void Update()
    {
    }
}
