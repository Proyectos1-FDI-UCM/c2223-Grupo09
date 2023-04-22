using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowControlls : MonoBehaviour
{
    [SerializeField] private Transform ElementoUI;
    [SerializeField] private float MovX;
    [SerializeField] private float MovY;
    [SerializeField] private float Time;
    [SerializeField] private TutorialControlesManager ControlesManager;
    [SerializeField] private int Message;
    private bool Show = true;
    private UIManager _uiManager;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.GetComponent<PlayerLifeComponent>() != null && Show)   //se comprueba si este tiene un Script de Life Component
        {
            StartCoroutine(Check());            
            Show = false;
            if (Message > 0)
            {
                ControlesManager.Message(Message);
            }
        }
    }
    IEnumerator MoveUI()
    {
        for (int i = 0; i < 20; i++)
        {
            ElementoUI.Translate(new Vector2(MovX, MovY));
            yield return new WaitForSeconds(0.025f);
        }
        yield return new WaitForSeconds(Time);
        for (int i = 0; i < 20; i++)
        {
            ElementoUI.Translate(new Vector2(MovX*-1, MovY*-1));
            yield return new WaitForSeconds(0.025f);
        }
        _uiManager.ShowingControles = false;
    }
    IEnumerator Check()
    {
        if (_uiManager.ShowingControles)
        {
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(Check());
        }
        else
        {
            _uiManager.ShowingControles = true;
            StartCoroutine(MoveUI());
            yield return new WaitForSeconds(0.1f);
        }
    }
    void Start()
    {
        _uiManager = GameObject.Find("UI").GetComponent<UIManager>();
    }
}
