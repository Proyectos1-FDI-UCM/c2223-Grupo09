using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendMessageToGM : MonoBehaviour
{
    [SerializeField] private bool Cabeza;
    private GameObject GameManager;
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerLifeComponent>() != null)   //se comprueba si este tiene un Script de Life Component
        {
            if (Cabeza) GameManager.GetComponent<GameManager>().Cabeza();
            else GameManager.GetComponent<GameManager>().Buho();
        }
    }

}
