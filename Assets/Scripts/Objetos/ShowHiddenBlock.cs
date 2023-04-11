using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHiddenBlock : MonoBehaviour
{
    private bool _change = false;
    private bool _playerInArea = false;
    private float x = 1f;
    private SpriteRenderer HiddenBlock;

    void Start()
    {
        HiddenBlock = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerLifeComponent>() != null)   //se comprueba si este tiene un Script de Life Component
        {
            _playerInArea = true;
            StartCoroutine(Hide());
        }
    }
    IEnumerator Hide()
    {        
        while (x>0.05f&&!_change)
        {
            HiddenBlock.color = new Color(1f, 1f, 1f, x);
            yield return new WaitForSeconds(0.05f);
            x -= 0.05f;
            if (!_playerInArea) _change=true;
        }
        _change = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerLifeComponent>() != null)   //se comprueba si este tiene un Script de Life Component
        {
            _playerInArea = false;
            StartCoroutine(Show());
        }
    }
    IEnumerator Show()
    {
        while (x < 1f && !_change)
        {
            HiddenBlock.color = new Color(1f, 1f, 1f, x);
            yield return new WaitForSeconds(0.05f);
            x += 0.05f;
            if (_playerInArea) _change = true;
        }
        _change = false;
    }
}
