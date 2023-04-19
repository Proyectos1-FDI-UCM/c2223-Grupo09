using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    #region references
    //private int _numEnemigos;
    private int[] _enemigos = new int[]  {1, 2, 2, 2, 5, 1, 3, 3,5,10,5,7,5,4,4,0,0};
    [SerializeField]
    private int _puerta;
    [SerializeField]
    private float alturaTope = 7.0f;
    [SerializeField]
    private float speed = 3.0f;
    private Vector2 newPosition;
    #endregion
    #region methods
    public void ContPuerta()
    {
        _enemigos[_puerta]--;
    }
    private void AbrePuerta()
    {
        transform.position = Vector2.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
    }
    #endregion
    void Start()
    {
        newPosition = new Vector2(transform.position.x, alturaTope);
        _puerta = ControladorDeSalas.Instance.Sala;
    }
    void Update()
    {
        _puerta = ControladorDeSalas.Instance.Sala;
        if(_puerta >=0) if (_enemigos[_puerta] == 0)
        {
            AbrePuerta();
        }
    }
  
}
