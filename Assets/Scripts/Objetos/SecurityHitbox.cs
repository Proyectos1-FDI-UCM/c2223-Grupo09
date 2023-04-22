using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityHitbox : MonoBehaviour
{
    private BoxCollider2D _myBoxCollider;
    [SerializeField] private GameObject RoomManager;
    private ControladorDeSalas _controladorDeSalas;
    [SerializeField] private int sala;
    // Start is called before the first frame update
    void Start()
    {
        _myBoxCollider = GetComponent<BoxCollider2D>();
        _controladorDeSalas = RoomManager.GetComponent<ControladorDeSalas>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_controladorDeSalas.Sala == sala)
        {
            _myBoxCollider.enabled = false;
        }
        else
        {
            _myBoxCollider.enabled = true;
        }        
    }
}
