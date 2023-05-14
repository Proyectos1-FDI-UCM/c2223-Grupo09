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
    #region Methods
    public float getDamage()
    { return _damage; }
    public void setDir(Vector2 v)
    { _dir = v; }
    private void Start()
    {
        _speed = 30.0f;
    }
    void Update()
    {
        transform.Translate(_dir * _speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<TutBossComponent>() != null) //la bala entra en contacto con el boss
        {
            collider.GetComponent<TutBossComponent>().IsAttacked(_damage); //se informa que se ha dañado al boss
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }
        if (collider.GetComponent<BossComponent>() != null) //la bala entra en contacto con el boss
        {
            collider.GetComponent<BossComponent>().IsAttacked(_damage); //se informa que se ha dañado al boss
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }
        if (collider.GetComponent<EnemyComponent>() != null) //la bala entra en contacto con los enemigos
        {
            collider.GetComponent<EnemyComponent>().IsAttacked(_damage); //se informa que se ha dañado al enemigo
            if (ControladorDeSalas.Instance.Sección != 5)
            {
                ControladorDeSalas.Instance.Kill(); //se llama al metodo que lleva el contador de enemigos
                ControladorPuertas.Instance.GetDoor(); //se llama al metodo que lleva el contador de enemigos para abrir las puertas

            }
        }
        if (collider.GetComponent<Escenario>() != null) //la bala se destruye al chocar con el escenario
        {
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<PlayerLifeComponent>() == null) Destroy(gameObject);
    }
    #endregion
}