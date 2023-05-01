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
    private int lastLogro2;
    private int Logro2 =0;
    private bool Logro6 = true;
    private bool Logro7 = true;
    #endregion
    #region Methods
    public void OnPickGear()
    {
        _gear++;
        Logro2++;
    }
    public void Hit()
    {
        puntos_vida--;
        Logro7 = false;
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
        if (_gear >= 10)
        {
            AudioControler.Instance.PlaySound(_compraEscudo);
            PlayerLifeComponent.Instance.ActivaEscudo();
            _gear = _gear - 10;
            Logro6 = false;
        }
    }
    public void CompraVida()
    {
        if (puntos_vida_max < 6)
        {
            if (_gear >= 20)
            {
                AudioControler.Instance.PlaySound(_compraVida);
                puntos_vida++;
                puntos_vida_max++;
                _gear = _gear - 20;
                Logro6 = false;
            }
        }
    }
    public void GuardaDatos()
    {
        lastGear = _gear;
        lastLogro2 = Logro2;
        lastPuntos_vida = puntos_vida;
        lastPuntos_vida_max = puntos_vida_max;
    }
    public void GuardaEngranajes()
    {
        lastGear = _gear;
        lastLogro2 = Logro2;
    }
    public void Respawn()
    {
        /*if (PlayerLifeComponent.Instance.CheckPoint == false && ControladorDeSalas.Instance.Sección ==0)
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
        }*/
        puntos_vida = lastPuntos_vida;
        puntos_vida_max = lastPuntos_vida_max;       
        _gear = lastGear;
        Logro2 = lastLogro2;
    }
    public void Escape()
    {
        GuardaDatos();
        Destroy(gameObject);
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void LogrosCheck()
    {
        if (GetComponent<Timer>() != null) GetComponent<Timer>().SaveData();
        if (Logro2 ==85) PlayerPrefs.SetInt("Engranajes", 1);
        if (Logro6) PlayerPrefs.SetInt("SinMejoras", 1);
        if (Logro7) PlayerPrefs.SetInt("Tocado", 1);
    }
    public void Cabeza()
    {        
        PlayerPrefs.SetInt("Cabeza", 1);
    }
    public void Buho()
    {
        PlayerPrefs.SetInt("Buho", 1);
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
