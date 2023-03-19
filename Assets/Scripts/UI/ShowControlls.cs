using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowControlls : MonoBehaviour
{
    [SerializeField] private Transform ElementoUI;
    private bool Show = true;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.GetComponent<PlayerLifeComponent>() != null && Show)   //se comprueba si este tiene un Script de Life Component
        {
            StartCoroutine(MoveUI());
            Show = false;
        }
    }
    IEnumerator MoveUI()
    {
        for (int i = 0; i < 20; i++)
        {
            ElementoUI.Translate(new Vector2(-20f, 0));
            yield return new WaitForSeconds(0.025f);
        }
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < 20; i++)
        {
            ElementoUI.Translate(new Vector2(20f, 0));
            yield return new WaitForSeconds(0.025f);
        }
    }
}
