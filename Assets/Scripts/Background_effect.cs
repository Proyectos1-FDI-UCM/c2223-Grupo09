using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_effect : MonoBehaviour
{
    #region references    
    private GameObject cam;     //referencias a la c�mara
    private Camera _cam;        
    #endregion
    #region properties
    private float _lenght;                  //variable que almacena el tama�o del sprite    
    private float _startPos;                //variable que guarda la posici�n de comienzo
    private float _dist;                    //distancia que ha de moverse el script respecto al _startPos
    private float _temp;                    //variable temporal usada para ver si se cambia el _startPos
    [SerializeField] private float _speed;  //velociadad a la que ocurre el parallex scrollex
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;     //referencia a la c�mara de forma autom�tica
        cam = _cam.gameObject;
        _startPos = transform.position.x;                           
        _lenght = GetComponent<SpriteRenderer>().bounds.size.x;     
    }

    // Update is called once per frame
    void Update()
    {
        _temp = cam.transform.position.x * (1 - _speed);
        _dist = cam.transform.position.x * _speed;                                      //la distancia que uno se mueve se calcula
        transform.position = new Vector2(_startPos + _dist, transform.position.y);      //se mueve hasta la posici�n inicial + la distancia calculada
        if (_temp > _startPos + _lenght) _startPos += _lenght;                          //si la c�mara se mueve demasiado hacia un lado, se cambia el _startpos
        else if (_temp < _startPos - _lenght) _startPos -= _lenght;                     //lo mismo, pero hacia el lado opuesto
    }
}
