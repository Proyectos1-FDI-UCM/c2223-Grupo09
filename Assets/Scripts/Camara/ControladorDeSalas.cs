using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeSalas : MonoBehaviour
{
    private static ControladorDeSalas _instance;
    public static ControladorDeSalas Instance
    {
        get
        {
            return _instance;
        }
    }
    #region references
    private Camera cam;                         //referencia a la cámara
    private Camera_movement _cam;               //referencia a su Script "Movement Component"
    [SerializeField] private Transform Punto1;  //referencia al Transform de los puntos del borde de cada sala
    [SerializeField] private Transform Punto2;  
    [SerializeField] private Transform Player;  //referencia al Transform del jugador
    #endregion
    #region properties
    [SerializeField] private int _sección;               //Cada sección del juego
    private int _sala;                  //Cada sala dentro de una sección
    const float ESPACIO_EXTRA = 2.0f;   //Espacio extra que tiene que avanzar el jugador para que haya un cambio de sala
    public int Sala          //acceso público a la variable de _sala
    {
        get { return _sala; }
    }
    public int Sección          //acceso público a la variable de _sección
    {
        get { return _sección; }
    }
    private int  _numtotalEnemigos;
    public int NumEnemigos          //acceso público a la variable de _numtotalEnemigos
    {
        get { return _numtotalEnemigos; }
    }
    private int[] _enemigos = new int[] { 1, 2, 2, 2, 5, 1, 3, 3,5,10,5,7,5,4,4,0,0}; //los enemigos de cada sala
    #endregion
    #region Methods
    private void ColocaciónDePuntos()   //void al que se llama cada vez que hay una transición de sala o de sección para colocar los puntos del borde de la cámara e informar del num de enemigos de cada una de ellas
    {
        if (_sección == 0)
        {
            if (_sala == 0)
            {
                Punto1.Translate(new Vector2(-9f - Punto1.position.x, 0));
                Punto2.Translate(new Vector2(55.5f - Punto2.position.x, 0));
                _numtotalEnemigos = _enemigos[0];

            } else if (_sala == 1)
            {
                Punto1.Translate(new Vector2(55.7f - Punto1.position.x, 0));
                Punto2.Translate(new Vector2(100.54f - Punto2.position.x, 0));
                _numtotalEnemigos = _enemigos[1];
            } else if (_sala == 2)
            {
                Punto1.Translate(new Vector2(100.54f - Punto1.position.x, 0));
                Punto2.Translate(new Vector2(158.75f - Punto2.position.x, 0));
                _numtotalEnemigos = _enemigos[2];
            }
            else if (_sala == 3)
            {
                Punto1.Translate(new Vector2(158.75f - Punto1.position.x, 0));
                Punto2.Translate(new Vector2(215.6f - Punto2.position.x, 0));
                _numtotalEnemigos = _enemigos[3];
            }
            else if (_sala == 4)
            {
                Punto1.Translate(new Vector2(215.6f - Punto1.position.x, 0));
                Punto2.Translate(new Vector2(264.82f - Punto2.position.x, 0));
                _numtotalEnemigos = _enemigos[4];
            }
           
        }
        else if (_sección == 1)
        {
            if (_sala == 5)
            {
                Punto1.Translate(new Vector2(-8.46f - Punto1.position.x, 0));
                Punto2.Translate(new Vector2(43.28f - Punto2.position.x, 0));
                _numtotalEnemigos = _enemigos[5];
            }
        }

        else if (_sección == 2)
        {
            if (_sala == 6)
            {
                Punto1.Translate(new Vector2(-9f - Punto1.position.x, 0));
                Punto2.Translate(new Vector2(15.5f - Punto2.position.x, 0));
                _numtotalEnemigos = _enemigos[6];

            }
            else if (_sala == 7)
            {
                Punto1.Translate(new Vector2(15.5f - Punto1.position.x, 0));
                Punto2.Translate(new Vector2(58.1f - Punto2.position.x, 0));
                _numtotalEnemigos = _enemigos[7];
            }
            else if (_sala == 8)
            {
                Punto1.Translate(new Vector2(58.1f - Punto1.position.x, 0));
                Punto2.Translate(new Vector2(83.5f - Punto2.position.x, 0));
                _numtotalEnemigos = _enemigos[8];
            }
            else if (_sala == 9)
            {
                Punto1.Translate(new Vector2(83.5f - Punto1.position.x, 0));
                Punto2.Translate(new Vector2(115f - Punto2.position.x, 0));
                _numtotalEnemigos = _enemigos[9];
            }
        }
        else if (_sección == 3)
        {
            if (_sala == 10)
            {
                Punto1.Translate(new Vector2(-7.58f - Punto1.position.x, 0));
                Punto2.Translate(new Vector2(19.3f - Punto2.position.x, 0));
                _numtotalEnemigos = _enemigos[10];

            }
            else if (_sala == 11)
            {
                Punto1.Translate(new Vector2(19.3f - Punto1.position.x, 0));
                Punto2.Translate(new Vector2(63.7f - Punto2.position.x, 0));
                _numtotalEnemigos = _enemigos[11];
            }
            else if (_sala == 12)
            {
                Punto1.Translate(new Vector2(63.7f - Punto1.position.x, 0));
                Punto2.Translate(new Vector2(97f - Punto2.position.x, 0));
                _numtotalEnemigos = _enemigos[12];
            }
            else if (_sala == 13)
            {
                Punto1.Translate(new Vector2(97f - Punto1.position.x, 0));
                Punto2.Translate(new Vector2(143f - Punto2.position.x, 0));
                _numtotalEnemigos = _enemigos[13];
            }
        }
        else if (_sección == 4)
        {
            if (_sala == 14)
            {
                Punto1.Translate(new Vector2(-8.7f - Punto1.position.x, 0));
                Punto2.Translate(new Vector2(29.85f - Punto2.position.x, 0));
                _numtotalEnemigos = _enemigos[14];

            }
            else if (_sala == 15)
            {
                Punto1.Translate(new Vector2(29.85f - Punto1.position.x, 0));
                Punto2.Translate(new Vector2(60.5f - Punto2.position.x, 0));
                _numtotalEnemigos = _enemigos[15];
            }
            else if (_sala == 16)
            {
                Punto1.Translate(new Vector2(60.5f - Punto1.position.x, 0));
                Punto2.Translate(new Vector2(94f - Punto2.position.x, 0));
                _numtotalEnemigos = _enemigos[16];
            }
            if (_sala == 13)
            {
                Punto1.Translate(new Vector2(-97f - Punto1.position.x, 0));
                Punto2.Translate(new Vector2(-8.7f - Punto2.position.x, 0));
                _numtotalEnemigos = _enemigos[13];
            }
        }
    }
    public void Kill() //metodo llamado para cada vez que se mata un enemigo restarlo del array
    {
        int i = Sala;
        _numtotalEnemigos = _enemigos[i];
        _numtotalEnemigos--;
        _enemigos[i] = _numtotalEnemigos;
    }
    #endregion
    // Start is called before the first frame update
    void Awake()
    {
        if (_instance != null && _instance != this) //Instanciar, hacer Singlenton este script
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }  
        //dependiendo de la sección, comienza en la sala correspondiente
        if(_sección ==0)
        {
             _sala = 0;
        }
        else if (_sección == 1)
        {
            _sala = 5;
        }
        else if (_sección == 2)
        {
            _sala = 6;
        }
        else if (_sección == 3)
        {
            _sala = 10;
        }
        else if (_sección == 4)
        {
            _sala = 14;
        }
        //Estos dos primeros parámetros son solo para la prueba. Deben cambiarse más tarde
        cam = Camera.main;
        _cam = cam.gameObject.GetComponent<Camera_movement>();
        ColocaciónDePuntos();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.position.x + ESPACIO_EXTRA <= Punto1.position.x)     //Si se avanza lo suficiente, se transiciona a la sección de delante
        {
            _sala--;
            _cam.movIzquierda();
            ColocaciónDePuntos();
        }
        if (Player.position.x - ESPACIO_EXTRA >= Punto2.position.x)     //Si se retrocede lo suficiente, se transiciona a la sección de detrás
        {
            _sala++;
            _cam.movDerecha();
            ColocaciónDePuntos();
        }
    }
}
