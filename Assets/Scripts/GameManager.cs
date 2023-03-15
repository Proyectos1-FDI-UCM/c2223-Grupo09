using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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

    private int puntos_vida; //cuenta el n�mero de vidas del jugador
    public int Puntos_vida   //acceso p�blico a los puntos de vida actuales del jugador
    {
        get { return puntos_vida; }
    }

    private int puntos_vida_max; //controla el n�mero m�ximo de vidas que puede tener el jugador. Empieza con 3, pero puede aumentar comprando m�s vidas con los engranajes
    public int Puntos_vida_max   //acceso p�blico a los de de vida maximos del jugador
    {
        get { return puntos_vida_max; }
    }
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
        puntos_vida = 3;     //siempre se empieza con tres vidas, se van perdiendo segun el da�o recibido
        puntos_vida_max = 3; //siempre se empieza con tres vidas como maximo, estas pueden aumentar cuando se compren con los engranajes
    }
    void Update()
    {
    }
}
