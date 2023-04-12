using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MonoBehaviour
{
    #region Parameters
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _damage;
    [SerializeField]
    private Vector2 _dir;
    #endregion

    #region References
    // private EnemyComponent _enemyComponent;
    //private OpenDoor _openDoor;
    #endregion

    #region Methods
    public float getDamage() 
    { return _damage; }
    public void setDir(Vector2 v)
    { _dir = v; }
    private void Start()
    {
        _speed = 30.0f;
        // _enemyComponent = GetComponent<EnemyComponent>();
    }   
    void Update()
    {
        transform.Translate(_dir * _speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<TutBossComponent>() != null)
        {
            collider.GetComponent<TutBossComponent>().IsAttacked(_damage);
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }
        if (collider.GetComponent<BossComponent>() != null)
        {
            collider.GetComponent<BossComponent>().IsAttacked(_damage);
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }
        //lo he cambiado para diferenciar enemigos con boss tutorial (ambos tienen killplayer pero solo los primeros tienen enemycomponent)
        if (collider.GetComponent<EnemyComponent>() != null) 
        // if (collider.GetComponent<KillPlayer>() != null)
        {
            collider.GetComponent<EnemyComponent>().IsAttacked(_damage);
            // if (collider.GetComponent<EnemyComponent>() != null) collider.GetComponent<EnemyComponent>().IsAttacked(_damage);
            if(ControladorDeSalas.Instance.Sección != 5)
            {
                ControladorDeSalas.Instance.Kill();
                ControladorPuertas.Instance.GetDoor();
            }
            if(gameObject != null)
            {
                Destroy(gameObject);
            }      
        }
        if (collider.GetComponent<Escenario>() != null)
        {
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.GetComponent<PlayerLifeComponent>() == null) Destroy(gameObject);
    }
    #endregion
}