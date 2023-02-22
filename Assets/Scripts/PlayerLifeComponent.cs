using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeComponent : MonoBehaviour
{
    #region references
    [SerializeField]
    private Vector2 _respawn;//posicion donde hace respawn el jugador
    private SpriteRenderer _mySpriteRenderer;
    #endregion
    #region properties
    private bool invulnerable;      //variable que vuelve invulnerable al jugador a todo da�o
    private int n�mero_vidas_m�x;   //variable que controla el n�mero m�ximo de vidas que puede tener el jugador
    private int puntos_vida;        //variable privada que cuenta el n�mero de vidas del jugador
    public int Puntos_vida          //acceso p�blico a la variable
    {
        get { return puntos_vida; }
    }
    #endregion
    #region Methods
    public void Hit()//metodo llamado desde el script KillPlayer de los enemigos
    {
        if (!invulnerable)
        {
        puntos_vida--;
        if(puntos_vida <= 0) Die();
        else
        {
            StartCoroutine(Invulnerable());
        }        
        }
    }
    public void Die()//metodo llamado desde el script KillPlayer de los enemigos
    {
        StartCoroutine(Respawn(0.5f));//tras 0,5 segundos llama al metodo Respawn
    }
    public void Botiqu�n()//metodo llamado desde el script KillPlayer de los enemigos
    {
        puntos_vida = n�mero_vidas_m�x;
    }
    #endregion
    private void Awake()
    {
        _mySpriteRenderer = GetComponent<SpriteRenderer>();
        puntos_vida = 3;
        n�mero_vidas_m�x = 3;
        invulnerable = false;
    }
    IEnumerator Respawn(float duration)
    {
        _mySpriteRenderer.enabled = false;//se vuelve invisible el jugador
        yield return new WaitForSeconds(duration);      
        puntos_vida = n�mero_vidas_m�x;
        _mySpriteRenderer.enabled = true;//se vuelve visible el jugador 
        transform.position = _respawn;//el transform del jugador en el momento en el que es eliminado pasa a ser la posicion del respawn
    }
    IEnumerator Invulnerable()
    {
        invulnerable = true;
        for (int i =0; i < 5; i++)
        {
            _mySpriteRenderer.enabled = false;//se vuelve invisible el jugador
            yield return new WaitForSeconds(0.1f);
            _mySpriteRenderer.enabled = true;//se vuelve visible el jugador
            yield return new WaitForSeconds(0.4f);
        }
        invulnerable = false;
    }
}
