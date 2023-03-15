using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeSalas : MonoBehaviour
{
    public static ControladorDeSalas Instance;
    #region references
    private Camera cam;                         //referencia a la cámara
    private Camera_movement _cam;               //referencia a su Script "Movement Component"
    [SerializeField] private Transform Punto1;  //referencia al Transform de los puntos del borde de cada sala
    [SerializeField] private Transform Punto2;  
    [SerializeField] private Transform Player;  //referencia al Transform del jugador
    
    #endregion
    #region properties
    private int _sección;               //Cada sección del juego
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
    public int NumEnemigos
    {
        get { return _numtotalEnemigos; }
    }
    private int _contEnemigos;
    public int ContEnemigos
    {
        get { return _contEnemigos; }
    }
    #endregion
    #region Methods
    private void ColocaciónDePuntos()   //void al que se llama cada vez que hay una transición de sala o de sección para colocar los puntos del borde de la cámara
    {
        if (_sección == 1)
        {
            if (_sala == 0)
            {
                Punto1.Translate(new Vector2(-9f - Punto1.position.x, 0));
                Punto2.Translate(new Vector2(55.5f - Punto2.position.x, 0));
                _contEnemigos=0;
                _numtotalEnemigos = 1;

            } else if (_sala == 1)
            {
                Punto1.Translate(new Vector2(55.5f - Punto1.position.x, 0));
                Punto2.Translate(new Vector2(113f - Punto2.position.x, 0));
                _contEnemigos = 0;
                _numtotalEnemigos = 2;
            } else if (_sala == 2)
            {
                Punto1.Translate(new Vector2(113f - Punto1.position.x, 0));
                Punto2.Translate(new Vector2(158.8f - Punto2.position.x, 0));
                _contEnemigos = 0;
                _numtotalEnemigos = 2;
            }
            else if (_sala == 3)
            {
                Punto1.Translate(new Vector2(158.8f - Punto1.position.x, 0));
                Punto2.Translate(new Vector2(215.6f - Punto2.position.x, 0));
                _contEnemigos = 0;
                _numtotalEnemigos = 2;
            }
            else if (_sala == 4)
            {
                Punto1.Translate(new Vector2(215.6f - Punto1.position.x, 0));
                Punto2.Translate(new Vector2(264.8f - Punto2.position.x, 0));
                _contEnemigos = 0;
                _numtotalEnemigos = 2;
            }
            else if (_sala == 5)
            {
                Punto1.Translate(new Vector2(264.8f - Punto1.position.x, 0));
                Punto2.Translate(new Vector2(400f - Punto2.position.x, 0));
                _contEnemigos = 0;
                _numtotalEnemigos = 3;
            }
        }
    }
    public void Kill()
    {
        _contEnemigos++;
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
        _sección = 1;
        _sala = 0;
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
