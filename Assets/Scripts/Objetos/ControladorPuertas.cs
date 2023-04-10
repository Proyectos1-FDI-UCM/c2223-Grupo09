using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPuertas : MonoBehaviour
{
    #region instance
    private static ControladorPuertas _instance;
    public static ControladorPuertas Instance
    {
        get
        {
            return _instance;
        }
    }
    #endregion
    #region references
    [SerializeField]
    private GameObject[] _puertas;
    private int _sala;
    private int _door;
    private OpenDoor _openDoor;
    private int _seccion;
    #endregion
    #region methods
    public void GetDoor()
    {
        Conversion();
        _openDoor = _puertas[_door].GetComponent<OpenDoor>();
        _openDoor.ContPuerta();
    }
    private void Conversion()
    {
        if (_seccion == 1)
        {
            _door = _sala - 5;
        }
        else if (_seccion == 2)
        {
            _door = _sala - 6;
        }
        else if (_seccion == 4)
        {
            _door = _sala - 14;
        }
        else
        {
            _door = _sala;
        }
    }
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
    }
    #endregion
    void Start()
    {
        _sala = ControladorDeSalas.Instance.Sala;
        _seccion = ControladorDeSalas.Instance.Sección;        
    }

    void LateUpdate()
    {
        //Conversion();
        _sala = ControladorDeSalas.Instance.Sala;
        _seccion = ControladorDeSalas.Instance.Sección;
    }
}
