using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeComponent : MonoBehaviour
{
    [SerializeField]
    Vector2 _respawn;//posicion donde hace respawn el jugador
    SpriteRenderer _mySpriteRenderer;

    #region Methods
    public void Die()//metodo llamado desde el script KillPlayer de los enemigos
    {
        StartCoroutine(Respawn(0.5f));//tras 0,5 segundos llama al metodo Respawn
    }
    #endregion
    private void Awake()
    {
        _mySpriteRenderer = GetComponent<SpriteRenderer>();
    }
    IEnumerator Respawn(float duration)
    {
        _mySpriteRenderer.enabled = false;//se vuelve invisible el jugador
        yield return new WaitForSeconds(duration);
        transform.position = _respawn;//el transform del jugador en el momento en el que es eliminado pasa a ser la posicion del respawn
        _mySpriteRenderer.enabled = true;//se vuelve visible el jugador 
    }
}
