using System.Collections;
using System.Collections.Generic;
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
  
    public int Gear //acceso publico al numero de engranajes
    {
        get
        {
            return _gear;
        }
    }
    #endregion
    #region Methods
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void OnPickGear()
    {
        _gear++;
    }
    #endregion
    void Start()
    {
        _gear = 0;
    }
    void Update()
    {
        
    }
}
