using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_movement : MonoBehaviour
{
    #region references
    private Transform cam_Transform;                        //Transform de la cámara principal
    [SerializeField] private Transform player_Transform;     //Transform del jugador (Se selecciona en el menú de Unity) 
    [SerializeField] private Transform PuntoBorde1;         //Transform de los puntos que marcan el principio y el final de cada sala
    [SerializeField] private Transform PuntoBorde2;         
    private Transform _punto1;
    private Transform _punto2;
    #endregion
    #region Methods
    public void movDerecha() //métodos para una transición entre salas
    {
        _borde = 2;
    }
    public void movIzquierda()
    {
        _borde = -2;
    }
    #endregion
    #region constantes
    const float DIST_LATERAL = 1.5f;
    const float DIST_VERTICAL= 2.0f;
    [SerializeField] float TAMAÑO_CAM = 9.0f;
    private float _posYMinim;
    private int _borde;
    #endregion
    void Start()
    {
        _borde = -1;
        cam_Transform = transform;
        _posYMinim = cam_Transform.position.y;
        if (PuntoBorde1.position.x > PuntoBorde2.position.x) //Un poco de programación defensiva, para que _punto1 sea el punto situado más a la izquierda
        {
            _punto2 = PuntoBorde1;
            _punto1 = PuntoBorde2;
        }
        else
        {
            _punto1 = PuntoBorde1;
            _punto2 = PuntoBorde2;
        }
    }
    void Update()
    {
        if (_borde == 0)
        {
            if (cam_Transform.position.x < (player_Transform.position.x - DIST_LATERAL))    //si la cámara esta mucho más a la izquierda que el jugador
            {
                if (cam_Transform.position.x <= _punto2.position.x - TAMAÑO_CAM)            //si no se pasa del borde de la sala
                {
                    cam_Transform.Translate(new Vector2((player_Transform.position.x - DIST_LATERAL) - cam_Transform.position.x, 0)); //Se mueve a la derecha lo mismo que el jugador
                }
                else _borde = 1; 
            }
            if (cam_Transform.position.x > (player_Transform.position.x + DIST_LATERAL))    //si la cámara esta mucho más a la derecha que el jugador
            {
                if (cam_Transform.position.x >= _punto1.position.x + TAMAÑO_CAM)            //si no se pasa del borde de la sala
                {
                    cam_Transform.Translate(new Vector2((player_Transform.position.x + DIST_LATERAL) - cam_Transform.position.x, 0)); //Se mueve a la izquierda lo mismo que el jugador
                }
                else _borde = -1;
            }            
        } else if (_borde == 1)     //este método situa la cámara lo más a la derecha posible sin que se asome a la siguiente sala
        {
            cam_Transform.Translate(new Vector2((_punto2.position.x - TAMAÑO_CAM)- cam_Transform.position.x, 0));           
            if (player_Transform.position.x < _punto2.position.x- TAMAÑO_CAM) _borde = 0;
        } else if (_borde == -1)    //este método situa la cámara lo más a la izquierda posible sin que se asome a la siguiente sala
        {
            cam_Transform.Translate(new Vector2((_punto1.position.x + TAMAÑO_CAM) - cam_Transform.position.x, 0));
            if (player_Transform.position.x > _punto1.position.x+ TAMAÑO_CAM) _borde = 0;
        } else if (_borde == -2)
        {
            StartCoroutine(MovIzquierda());
            _borde = 3;
        } else if (_borde == 2)
        {
            StartCoroutine(MovDerecha());
            _borde = 3;
        }
        if (cam_Transform.position.y > (player_Transform.position.y + DIST_VERTICAL))   //si la cámara esta mucho más arriba que el jugador
        {
            if (cam_Transform.position.y > _posYMinim)                                    //si está más arriba de la posición mínima de Y
            {
                cam_Transform.Translate(new Vector2(0, (player_Transform.position.y + DIST_VERTICAL) - cam_Transform.position.y)); //Se mueve hacia abajo lo mismo que el jugador
            }
        }
        if (cam_Transform.position.y < (player_Transform.position.y - DIST_VERTICAL))   //si la cámara esta mucho más debajo que el jugador
        {
            cam_Transform.Translate(new Vector2(0, (player_Transform.position.y - DIST_VERTICAL) - cam_Transform.position.y)); //Se mueve hacia arriba lo mismo que el jugador
        }
    }
    IEnumerator MovIzquierda()  //Crea una transición fluida a la sala situada a la izquierda
    {        
        for (float i = 0; i < TAMAÑO_CAM * 4; i++)
        {
            cam_Transform.Translate(new Vector2(-0.5f, 0));
            yield return new WaitForSeconds(0.01f);
        }
        _borde = 1;
    }
    IEnumerator MovDerecha()    //Crea una transición fluida a la sala situada a la derecha
    {        
        for (float i = 0; i < TAMAÑO_CAM * 4; i++)                          
        {
            cam_Transform.Translate(new Vector2(0.5f, 0));
            yield return new WaitForSeconds(0.01f);
        }
        _borde = -1;
    }
}
