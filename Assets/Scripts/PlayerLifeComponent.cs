using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeComponent : MonoBehaviour
{
    [SerializeField]
    Vector2 _respawn;
    SpriteRenderer _mySpriteRenderer;

    #region Methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Die();
        }
    }
    private void Die()
    {
        StartCoroutine(Respawn(0.5f));
    }
    #endregion
    private void Awake()
    {
        _mySpriteRenderer = GetComponent<SpriteRenderer>();
    }
    IEnumerator Respawn(float duration)
    {
        _mySpriteRenderer.enabled = false;
        yield return new WaitForSeconds(duration);
        transform.position = _respawn;
        _mySpriteRenderer.enabled = true;
    }
}
