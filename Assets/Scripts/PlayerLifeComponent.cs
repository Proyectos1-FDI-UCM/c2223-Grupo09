using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeComponent : MonoBehaviour
{
    public static PlayerLifeComponent Instance;//Para hacer Singleton este script y asi poder acceder a sus variables y/o Metodos
    #region references
    [SerializeField]
    private Vector2 _respawn;                   //posicion donde hace respawn el jugador (Deber�a ajustarse seg�n el nivel)
    private SpriteRenderer _mySpriteRenderer;   //referencia al sprite Reneder
    #endregion
    #region properties
    private bool invulnerable;      //variable que vuelve invulnerable al jugador a todo da�o. Se usa cuando es golpeado, y se usar� con los escudos es un futuro
    private int puntos_vida_max;   //variable que controla el n�mero m�ximo de vidas que puede tener el jugador. Esta empieza con 3, pero puede aumentar seg�n vaya comprando m�s vidas con los engranajes
    private int puntos_vida;        //variable privada que cuenta el n�mero de vidas actuales del jugador
    public int Puntos_vida          //acceso p�blico a la variable de puntos de vida
    {
        get { return puntos_vida; }
    }
    public int Puntos_vida_max   //acceso p�blico a la variable de puntos de vida maximos
    {
        get { return puntos_vida_max; }
    }
    #endregion
    #region Methods
    public void Hit()       //metodo llamado desde el script KillPlayer de los enemigos
    {
        if (!invulnerable)                      //si no es invulnerable (por escudo o porque ya ha sido golpeado)
        {
        puntos_vida--;                          //menos una vida
        if(puntos_vida <= 0) Die();             //si llega a cero vidas, se activa el void de muerte
        else StartCoroutine(Invulnerable());    //si no ha llegado a cero vidas, se vuelve invulnerable  
        }
    }
    public void Die()       
    {
        StartCoroutine(Respawn(0.5f));          //reaparece al principio del nivel
    }
    public void Botiqu�n()                      //metodo llamado desde el script Botiqu�n
    {
        puntos_vida = puntos_vida_max;         //se curan todas las vidas del jugador
        
    }
    public void SpikeDamage() //metodo llamado desde el script SpikeSaws (matan al jugador, es decir eliminan todas las vidas)
    {
        puntos_vida = 0;
        Die();
    }
    #endregion
     void Awake()
     {
        if (Instance != null && Instance != this) //Instanciar, hacer Singlenton este script
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        _mySpriteRenderer = GetComponent<SpriteRenderer>();
        puntos_vida = 3;//siempre se va a empezar con 3 corazones de vida
        puntos_vida_max = 3;//variable que ira cambiando despues cuando se puedan a�adir mas corazones
        invulnerable = false;
     }
    IEnumerator Respawn(float duration)
    {
        _mySpriteRenderer.enabled = false;              //se vuelve invisible el jugador
        yield return new WaitForSeconds(duration);      //se espera
        puntos_vida = puntos_vida_max;                 //se recuperan todas las vidas
        _mySpriteRenderer.enabled = true;               //se vuelve visible el jugador 
        transform.position = _respawn;                  //el transform del jugador en el momento en el que es eliminado pasa a ser la posicion del respawn
    }
    IEnumerator Invulnerable()
    {
        invulnerable = true;                                //se vuelve invulnerable al jugador
        for (int i =0; i < 5; i++)                          //este bucle for est� aqu� para hacer un efecto de parpadeo del jugador
        {
            _mySpriteRenderer.enabled = false;              //se vuelve invisible el jugador
            yield return new WaitForSeconds(0.1f);
            _mySpriteRenderer.enabled = true;               //se vuelve visible el jugador
            yield return new WaitForSeconds(0.4f);
        }
        invulnerable = false;                               //despu�s del tiempo de espera, se le quita la invulnerabilidad al jugador [ATENCI�N: Cuando se haga el script del escudo protector
                                                            //hay que vijilar que este IEnumerator no pueda desactivar la invencibilidad antes de que se acabe el tiempo del propio escudo]
    }
}
