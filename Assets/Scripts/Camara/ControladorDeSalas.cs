using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeSalas : MonoBehaviour
{
    public static ControladorDeSalas Instance;
    #region references
    private Camera cam;                         //referencia a la c�mara
    private Camera_movement _cam;               //referencia a su Script "Movement Component"
    [SerializeField] private Transform Punto1;  //referencia al Transform de los puntos del borde de cada sala
    [SerializeField] private Transform Punto2;  
    [SerializeField] private Transform Player;  //referencia al Transform del jugador

    #endregion
    #region properties
    [SerializeField] private int _secci�n;               //Cada secci�n del juego
    private int _sala;                  //Cada sala dentro de una secci�n
    const float ESPACIO_EXTRA = 2.0f;   //Espacio extra que tiene que avanzar el jugador para que haya un cambio de sala
    public int Sala          //acceso p�blico a la variable de _sala
    {
        get { return _sala; }
    }
    public int Secci�n          //acceso p�blico a la variable de _secci�n
    {
        get { return _secci�n; }
    }
    private int  _numtotalEnemigos;
    public int NumEnemigos
    {
        get { return _numtotalEnemigos; }
    }
    private int[] _enemigos = new int[] { 1, 2, 2, 2, 5, 1, 3, 3 };
    #endregion
    #region Methods
    private void Colocaci�nDePuntos()   //void al que se llama cada vez que hay una transici�n de sala o de secci�n para colocar los puntos del borde de la c�mara
    {
        if (_secci�n == 1)
        {
            if (_sala == 0)
            {
                Punto1.Translate(new Vector2(-9f - Punto1.position.x, 0));
                Punto2.Translate(new Vector2(55.5f - Punto2.position.x, 0));
                _numtotalEnemigos = _enemigos[0];

            } else if (_sala == 1)
            {
                Punto1.Translate(new Vector2(55.7f - Punto1.position.x, 0));
                Punto2.Translate(new Vector2(113f - Punto2.position.x, 0));
                _numtotalEnemigos = _enemigos[1];
            } else if (_sala == 2)
            {
                Punto1.Translate(new Vector2(113f - Punto1.position.x, 0));
                Punto2.Translate(new Vector2(158.8f - Punto2.position.x, 0));
                _numtotalEnemigos = _enemigos[2];
            }
            else if (_sala == 3)
            {
                Punto1.Translate(new Vector2(158.8f - Punto1.position.x, 0));
                Punto2.Translate(new Vector2(215.6f - Punto2.position.x, 0));
                _numtotalEnemigos = _enemigos[3];
            }
            else if (_sala == 4)
            {
                Punto1.Translate(new Vector2(215.6f - Punto1.position.x, 0));
                Punto2.Translate(new Vector2(265.6f - Punto2.position.x, 0));
                _numtotalEnemigos = _enemigos[4];
            }
            else if (_sala == 5)
            {
                Punto1.Translate(new Vector2(266.5f - Punto1.position.x, 0));
                Punto2.Translate(new Vector2(318.3f - Punto2.position.x, 0));
                _numtotalEnemigos = _enemigos[5];
            }

        }

        else if (_secci�n == 2)
        {
            if (_sala == 6)
            {
                Punto1.Translate(new Vector2(-9f - Punto1.position.x, 0));
                Punto2.Translate(new Vector2(15.6f - Punto2.position.x, 0));
                _numtotalEnemigos = _enemigos[6];

            }
            else if (_sala == 7)
            {
                Punto1.Translate(new Vector2(15.6f - Punto1.position.x, 0));
                Punto2.Translate(new Vector2(58.22f - Punto2.position.x, 0));
                _numtotalEnemigos = _enemigos[7];
            }
            else if (_sala == 8)
            {
                Punto1.Translate(new Vector2(58.22f - Punto1.position.x, 0));
                Punto2.Translate(new Vector2(158.8f - Punto2.position.x, 0));
                _numtotalEnemigos = _enemigos[2];
            }
            else if (_sala == 9)
            {
                Punto1.Translate(new Vector2(158.8f - Punto1.position.x, 0));
                Punto2.Translate(new Vector2(215.6f - Punto2.position.x, 0));
                _numtotalEnemigos = _enemigos[3];
            }
            else if (_sala == 10)
            {
                Punto1.Translate(new Vector2(215.6f - Punto1.position.x, 0));
                Punto2.Translate(new Vector2(265.6f - Punto2.position.x, 0));
                _numtotalEnemigos = _enemigos[4];
            }
            else if (_sala == 11)
            {
                Punto1.Translate(new Vector2(266.5f - Punto1.position.x, 0));
                Punto2.Translate(new Vector2(318.3f - Punto2.position.x, 0));
                _numtotalEnemigos = _enemigos[5];
            }
            /*else if (_sala == 6)
            {
                Punto1.Translate(new Vector2(318.3f - Punto1.position.x, 0));
                Punto2.Translate(new Vector2(500f - Punto2.position.x, 0));
                _numtotalEnemigos = 3;
            }*/
        }
    }
    public void Kill()
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
        if (Instance != null && Instance != this) //Instanciar, hacer Singlenton este script
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }  
        
        if(_secci�n == 1)
        {
             _sala = 0;
        }
        else if (_secci�n == 2)
        {
            _sala = 6;
        }

        //Estos dos primeros par�metros son solo para la prueba. Deben cambiarse m�s tarde
        cam = Camera.main;
        _cam = cam.gameObject.GetComponent<Camera_movement>();
        Colocaci�nDePuntos();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.position.x + ESPACIO_EXTRA <= Punto1.position.x)     //Si se avanza lo suficiente, se transiciona a la secci�n de delante
        {
            _sala--;
            _cam.movIzquierda();
            Colocaci�nDePuntos();
        }
        if (Player.position.x - ESPACIO_EXTRA >= Punto2.position.x)     //Si se retrocede lo suficiente, se transiciona a la secci�n de detr�s
        {
            _sala++;
            _cam.movDerecha();
            Colocaci�nDePuntos();
        }
    }
}
