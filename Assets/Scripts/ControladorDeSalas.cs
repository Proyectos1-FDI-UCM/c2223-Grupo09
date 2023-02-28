using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeSalas : MonoBehaviour
{
    #region references
    private Camera cam;                         //referencia a la c�mara
    private Camera_movement _cam;               //referencia a su Script "Movement Component"
    [SerializeField] private Transform Punto1;  //referencia al Transform de los puntos del borde de cada sala
    [SerializeField] private Transform Punto2;  
    [SerializeField] private Transform Player;  //referencia al Transform del jugador
    #endregion
    #region properties
    private int _secci�n;               //Cada secci�n del juego
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
    #endregion
    #region Methods
    private void Colocaci�nDePuntos()   //void al que se llama cada vez que hay una transici�n de sala o de secci�n para colocar los puntos del borde de la c�mara
    {
        if (_secci�n == 1)
        {
            if (_sala == 0)
            {
                Punto1.Translate(new Vector2(-9f - Punto1.position.x, 0));
                Punto2.Translate(new Vector2(60.9f - Punto2.position.x, 0));
            } else if (_sala == 1)
            {
                Punto1.Translate(new Vector2(60.9f - Punto1.position.x, 0));
                Punto2.Translate(new Vector2(112.5f - Punto2.position.x, 0));
            } else if (_sala == 2)
            {
                Punto1.Translate(new Vector2(112.5f - Punto1.position.x, 0));
                Punto2.Translate(new Vector2(200f - Punto2.position.x, 0));
            }
        }
    }
    #endregion
    // Start is called before the first frame update
    void Awake()
    {
        _secci�n = 1;
        _sala = 0;
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