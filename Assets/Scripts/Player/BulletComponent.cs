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
    // Update is called once per frame
    void Update()
    {
        transform.Translate(_dir * _speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<KillPlayer>() != null)
        {
            if (collider.GetComponent<EnemyComponent>() != null) collider.GetComponent<EnemyComponent>().IsAttacked(_damage);
            ControladorDeSalas.Instance.Kill();
            ControladorPuertas.Instance.GetDoor();
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
        if (collider.GetComponent<BossComponent>() != null)
        {
            collider.GetComponent<BossComponent>().IsAttacked(_damage);
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }
        if (collider.GetComponent<TutBossComponent>() != null)
        {
            collider.GetComponent<TutBossComponent>().IsAttacked(_damage);
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }
    }
    #endregion
}